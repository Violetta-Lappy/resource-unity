using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore {
    public class ManagerInput : SingletonBlank<ManagerInput> {

        public enum ENUM_MOUSE_BUTTON_PHASE {
            CLICK,
            HOLD,
            RELEASE
        }

        public ControllerPlayer m_controllerPlayer;        
        
        public UnityEngine.Vector3 vec3_pos;
        [SerializeField] private bool isClickTapOnce = false;
        [SerializeField] private bool isAllowInput = true;

        private void Start() => DisableInputTemporary();

        void Update() {
            if (isAllowInput == false) return; //early-exit
            UpdateInputMouse();
            UpdateInputTouch();            
        }

        public bool IsAllowInput() { return isAllowInput; }

        public void DisableInputTemporary() {
            StopCoroutine(RoutineDisableInputTemporary()); //Stop-stacking-couroutine
            StartCoroutine(RoutineDisableInputTemporary()); 
        }

        private IEnumerator RoutineDisableInputTemporary() {
            isAllowInput = false;
            GUIManager.Instance.UpdateGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE.DISABLE_INPUT);
            yield return new WaitForSeconds(2.0f);
            isAllowInput = true;
            GUIManager.Instance.UpdateGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE.DISABLE_INPUT);
        }

        public void UpdateInputMouse() {                        
            vec3_pos = UnityEngine.Input.mousePosition; //Get position from Mouse Position

            //Add and replace all the input here
            if (UnityEngine.Input.GetMouseButtonDown(0)) HandleMouseButton(ENUM_MOUSE_BUTTON_PHASE.CLICK);            
            if (UnityEngine.Input.GetMouseButton(0)) HandleMouseButton(ENUM_MOUSE_BUTTON_PHASE.HOLD);            
            if (UnityEngine.Input.GetMouseButtonUp(0)) HandleMouseButton(ENUM_MOUSE_BUTTON_PHASE.RELEASE);            
        }

        public void UpdateInputTouch() {            
            if (UnityEngine.Input.touchCount == 1) {                

                UnityEngine.Touch touch = UnityEngine.Input.touches[0]; //Only get the touch from touches 0
                vec3_pos = touch.position; //Get position from Touch, if detect one touch input

                //Add and replace all the input here
                if (touch.phase == UnityEngine.TouchPhase.Began) HandleTouch(UnityEngine.TouchPhase.Began);
                if (touch.phase == UnityEngine.TouchPhase.Stationary) HandleTouch(UnityEngine.TouchPhase.Stationary);
                if (touch.phase == UnityEngine.TouchPhase.Ended) HandleTouch(UnityEngine.TouchPhase.Ended);                
            }            
        }

        private void HandleMouseButton(ENUM_MOUSE_BUTTON_PHASE _type) {            
            switch (_type) {
                case ENUM_MOUSE_BUTTON_PHASE.CLICK: LogicClickTap(); break;
                case ENUM_MOUSE_BUTTON_PHASE.HOLD: LogicHold(); break;
                case ENUM_MOUSE_BUTTON_PHASE.RELEASE: LogicRelease(); break;
                default: break;
            }
        }

        private void HandleTouch(UnityEngine.TouchPhase _type) {            
            switch (_type) {
                case UnityEngine.TouchPhase.Began: LogicClickTap(); break;
                case UnityEngine.TouchPhase.Stationary: LogicHold(); break;
                case UnityEngine.TouchPhase.Ended: LogicRelease(); break;
                default: break;
            }
        }

        public void LogicClickTap() {
            
            if (isClickTapOnce == true) return;            

            if (m_controllerPlayer.IsFeverMode() == false) {
                if (m_controllerPlayer.IsSafeLand()) {
                    m_controllerPlayer.SetControllerParentToPlatform();
                    m_controllerPlayer.SetRotationStatusToRight(!m_controllerPlayer.IsRotateRight()); //Set rotation status to reversal of its own status

                    AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE.HUB_CLICK);
                }
                else ManagerGame.Instance.SetGameOverStatus(true, ENUM_GAMEOVER_TYPE.LOSE);
            }

            isClickTapOnce = true;
        }

        public void LogicHold() {
            if (m_controllerPlayer.IsFeverMode()) m_controllerPlayer.RotateFever();
        }

        public void LogicRelease() => isClickTapOnce = false;
    }
}


