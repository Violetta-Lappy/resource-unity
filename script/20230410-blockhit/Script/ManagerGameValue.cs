using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGameValue : SingletonBlank<ManagerGameValue> {
    public enum ENUM_VALUE_TYPE {
        HIGHSCORE,
        TIMER,
        COMBO,
        FEVER_VALUE,
        OBSTACLE_LEFT,
        FEVER_CONDITION
    }

    [SerializeField] private int i32_highscore;
    [SerializeField] private float f_timer;
    [SerializeField] private int i32_combo;
    [SerializeField] private float f_fever;
    [SerializeField] private int i32_obstacleLeft;

    [SerializeField] private ComponentPlayerStart m_componentPlayerStart;
    [SerializeField] private List<ComponentObstacle> list_m_componentObstacle;    

    private void Start() {
        CancelInvoke();

        ResetSpecificValue(ENUM_VALUE_TYPE.TIMER);
        if(ManagerGame.Instance.IsGameMode(ENUM_GAMEMODE_TYPE.TIMEATTACK)) InvokeRepeating(nameof(DecreaseTimer), 1.0f, 1.0f);
    }

    private void Update() {
        if (ControllerPlayer.Instance.IsFeverMode()) DecreaseFever(Time.deltaTime * 10.0f);
        //else if (ControllerPlayer.Instance.IsFeverMode() == false) IncreaseFever(0.5f);
    }    

    public void SetComponentPlayerStart(ComponentPlayerStart _componentPlayerStart) { m_componentPlayerStart = _componentPlayerStart; }

    public void AddToObstacleList(ComponentObstacle _obstacle) => list_m_componentObstacle.Add(_obstacle);
    public void ClearObstacleList() => list_m_componentObstacle.Clear();

    public void ResetSpecificValue(ENUM_VALUE_TYPE _type) {
        switch (_type) {
            case ENUM_VALUE_TYPE.HIGHSCORE: 
                i32_highscore = 0;
                OnValueChange(ENUM_VALUE_TYPE.HIGHSCORE);
                break;
            case ENUM_VALUE_TYPE.TIMER: 
                f_timer = 120.0f;
                OnValueChange(ENUM_VALUE_TYPE.TIMER);
                break;
            case ENUM_VALUE_TYPE.FEVER_VALUE: f_fever = 0; break;
            case ENUM_VALUE_TYPE.OBSTACLE_LEFT: 
                i32_obstacleLeft = 0;
                OnValueChange(ENUM_VALUE_TYPE.OBSTACLE_LEFT);
                break;
            case ENUM_VALUE_TYPE.FEVER_CONDITION: ControllerPlayer.Instance.SetStatusFeverMode(false); break;
            default: break;
        }
    }

    public int GetValueHighScore() { return i32_highscore; }
    public float GetValueTimer() { return f_timer; }
    public float GetValueFever() { return f_fever; }
    public int GetValueObstacleLeft() { return i32_obstacleLeft; }
    public int GetValueCombo() { return i32_combo; }

    public void ResetAllValue() {
        ResetSpecificValue(ENUM_VALUE_TYPE.HIGHSCORE);
    }

    public void SetStatusFever(bool _status) => ControllerPlayer.Instance.SetStatusFeverMode(_status);

    public void IncreaseScore() {
        i32_highscore += 50;
        OnValueChange(ENUM_VALUE_TYPE.HIGHSCORE);
    }        

    public void DecreaseTimer() {
        f_timer -= 1.0f;
        OnValueChange(ENUM_VALUE_TYPE.TIMER);
    }

    public void IncreaseCombo() {
        i32_combo += 1;
        OnValueChange(ENUM_VALUE_TYPE.COMBO);
    }

    public void IncreaseFever(float value) {
        f_fever += value;
        OnValueChange(ENUM_VALUE_TYPE.FEVER_VALUE);
    }

    public void DecreaseFever(float value) {
        f_fever -= value;
        OnValueChange(ENUM_VALUE_TYPE.FEVER_VALUE);
    }

    public void IncreaseObstacleLeft() {
        i32_obstacleLeft += 1;
        OnValueChange(ENUM_VALUE_TYPE.OBSTACLE_LEFT);
    }

    public void DecreaseObstacleLeft() {
        i32_obstacleLeft -= 1;
        OnValueChange(ENUM_VALUE_TYPE.OBSTACLE_LEFT);
    }

    private void OnValueChange(ENUM_VALUE_TYPE _type) {
        switch (_type) {
            case ENUM_VALUE_TYPE.HIGHSCORE: GUIManager.Instance.UpdateGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE.HIGHSCORE); break;
            case ENUM_VALUE_TYPE.TIMER: 
                                                
                if(f_timer <= 0.0f) {                    
                    CancelInvoke();
                    ManagerGame.Instance.SetGameOverStatus(true, ENUM_GAMEOVER_TYPE.LOSE);
                }

                GUIManager.Instance.UpdateGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE.TIMER);

                break;
            case ENUM_VALUE_TYPE.COMBO: GUIManager.Instance.UpdateGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE.COMBO); break;
            case ENUM_VALUE_TYPE.FEVER_VALUE:
                if (f_fever <= 0.0f) {
                    ResetSpecificValue(ENUM_VALUE_TYPE.FEVER_VALUE);
                    ResetSpecificValue(ENUM_VALUE_TYPE.FEVER_CONDITION);
                    ControllerPlayer.Instance.SetRootPosition(m_componentPlayerStart.transform.position);
                    GameCore.ManagerInput.Instance.DisableInputTemporary();
                }

                else if (f_fever >= 100.0f) {
                    f_fever = 100.0f;
                    SetStatusFever(true);
                }

                GUIManager.Instance.UpdateGUIElementSlider(ENUM_GUIELEMENT_SLIDER_TYPE.FEVER);
                break;
            case ENUM_VALUE_TYPE.OBSTACLE_LEFT:
                if (i32_obstacleLeft <= 0) {
                    FactoryLevel.Instance.ChangeNewLevel();
                }
                break;
            case ENUM_VALUE_TYPE.FEVER_CONDITION: break;

            default: break;
        }
    }
}
