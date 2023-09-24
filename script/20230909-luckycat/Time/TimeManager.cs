using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;
using VLGameProject.VLGameProgram;
using VLGameProject.VLGui;

namespace VLGameProject.VLTime {
    public class TimeManager : GameProgramObject {

        public enum ENUM_TIMEMANAGER_TYPE {
            K_APP_TIMEELAPSE = 0,
            K_GAME_TIMEELAPSE = 1,
            K_GAME_TIMECOUNTDOWN = 2,
            K_GAME_TIMECONSTRAINT = 3,
        }

        [Header("Behavior")]
        public UltEvent OnAppFocus;
        public UltEvent OnAppNotFocus;
        public UltEvent OnAppQuit;
        public UltEvent OnAppTimeElapse;
        public UltEvent OnGameTimeElapse;
        public UltEvent OnGameTimeCountdown;
        public UltEvent OnGameTimeCountdownEnd;
        public UltEvent OnGameTimeRestraintReach;

        [Header("Variable")]
        public ProgramValue m_appTimeElapse = new ProgramValue(0, 0, float.MinValue, float.MaxValue, float.MinValue, float.MaxValue);
        public ProgramValue m_gameTimeElapse = new ProgramValue(0, 0, float.MinValue, float.MaxValue, float.MinValue, float.MaxValue);
        public ProgramValue m_gameTimeCountdown = new ProgramValue(0, 0, float.MinValue, float.MaxValue, float.MinValue, float.MaxValue);
        public ProgramValue m_gameTimeConstraint = new ProgramValue(0, 0, float.MinValue, float.MaxValue, float.MinValue, float.MaxValue);
        public ProgramValue m_gameTimeRestraint = new ProgramValue(0, 0, float.MinValue, float.MaxValue, float.MinValue, float.MaxValue);

        public override void Awake() {
            base.Awake();
            OnAppFocus += InvokeRepeat_IncreaseAppTimeElapse;
            OnAppNotFocus += CancelInvoke_IncreaseAppTimeElapse;
            OnAppQuit += CancelInvoke;
        }

        public override void Start() {
            InvokeRepeating(nameof(Increase_GameTimeElapse), 1.0f, 1.0f);
            InvokeRepeating(nameof(Decrease_GameTimeCountdown), 1.0f, 1.0f);
        }

        public override void Update() {

        }

        public void Set_GameTimeCountdown(float arg_value) {
            m_gameTimeCountdown.Set_Value(m_gameTimeCountdown.Get_Value() + arg_value);
            OnGameTimeCountdown?.Invoke();
        }

        public void Set_GameTimeRestraint(float arg_value) {
            m_gameTimeRestraint.Set_Value(m_gameTimeRestraint.Get_Value() + arg_value);
            OnGameTimeRestraintReach?.Invoke();
        }

        public string Get_DayAndTime() { return "something"; }
        public string Get_Time() { return "something"; }

        public float Get_GameTimeCountdown() { return m_gameTimeCountdown.Get_Value(); }

        public void Increase_AppTimeElapse(float _value = 1) {
            m_appTimeElapse.Set_Value(m_appTimeElapse.Get_Value() + _value);
            OnAppTimeElapse?.Invoke();
        }

        public void Increase_GameTimeElapse(float _value = 1) {
            m_gameTimeElapse.Set_Value(m_gameTimeElapse.Get_Value() + _value);
            OnGameTimeElapse?.Invoke();
        }

        public void Increase_GameTimeCountdown(float _value = 1.0f) {
            m_gameTimeCountdown.Set_Value(m_gameTimeCountdown.Get_Value() + _value);
            OnGameTimeCountdown?.Invoke();
        }

        public void Decrease_GameTimeCountdown() {
            m_gameTimeCountdown.Set_Value(m_gameTimeCountdown.Get_Value() - 1.0f);
            OnGameTimeCountdown?.Invoke();
        }

        public void Decrease_GameTimeCountdown(float _value = 1.0f) {
            m_gameTimeCountdown.Set_Value(m_gameTimeCountdown.Get_Value() - _value);
            TimeManager_Event(ENUM_TIMEMANAGER_TYPE.K_GAME_TIMECOUNTDOWN);
        }

        private void TimeManager_Event(ENUM_TIMEMANAGER_TYPE _type) {
            switch (_type) {
                case ENUM_TIMEMANAGER_TYPE.K_APP_TIMEELAPSE:
                    break;
                case ENUM_TIMEMANAGER_TYPE.K_GAME_TIMEELAPSE:
                    break;
                case ENUM_TIMEMANAGER_TYPE.K_GAME_TIMECOUNTDOWN:
                    Get_GameProgram().Get_GuiManager().Update_GuiElementText(ENUMGuiText.K_GameplayValue_TimeElapse);

                    if (m_gameTimeCountdown.Get_Value() <= 0) {
                        Debug.Log("Time have countdown !!");
                        CancelInvoke(); //cancel-all-couroutine-invoke
                        OnGameTimeCountdownEnd?.Invoke();
                    }
                    break;
                case ENUM_TIMEMANAGER_TYPE.K_GAME_TIMECONSTRAINT:
                    OnGameTimeRestraintReach?.Invoke();
                    break;
                default:
                    break;
            }
        }

        private void OnApplicationFocus(bool focus) {
            if (focus) {
                OnAppFocus?.Invoke();
            }
            else if (focus == false) {
                OnAppNotFocus?.Invoke();
            }
        }

        public void InvokeRepeat_IncreaseAppTimeElapse() => InvokeRepeating(nameof(Increase_AppTimeElapse), 1.0f, 1.0f);
        public void CancelInvoke_IncreaseAppTimeElapse() => CancelInvoke(nameof(Increase_AppTimeElapse));

        private void OnApplicationQuit() => OnAppQuit?.Invoke();
    }
}
