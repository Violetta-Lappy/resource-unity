using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryLevel : SingletonBlank<FactoryLevel> {
    [SerializeField] private GameObject[] sz_m_gameObject;
    [SerializeField] private GameObject m_currentGameObject;
    [SerializeField] private int i32_levelRemaining;
    [SerializeField] private int i32_levelCurrent;
    [SerializeField] private int i32_levelNext;
    [SerializeField] private int i32_levelProgression; //0 to 2

    private void Start() { 
        ResetAllValue();

        StartCoroutine(RoutineSpawnLevelDelayAtStart());
    }

    private void Update() { }

    IEnumerator RoutineSpawnLevelDelayAtStart() {
        yield return new WaitForSeconds(2.0f);
        m_currentGameObject = GetRandomLevel();
    }

    public void ResetAllValue() {
        i32_levelRemaining = 3;
        i32_levelProgression = 0;
        i32_levelCurrent = 1;
        i32_levelNext = 2;
    }

    public int GetValueLevelProgression() { return i32_levelProgression; }
    public int GetValueLevelCurrent() { return i32_levelCurrent; }
    public int GetValueLevelNext() { return i32_levelNext; }

    public void ChangeNewLevel() {         
        ManagerGameValue.Instance.ResetSpecificValue(ManagerGameValue.ENUM_VALUE_TYPE.TIMER);
        ManagerGameValue.Instance.ResetSpecificValue(ManagerGameValue.ENUM_VALUE_TYPE.TIMER);

        IncreaseLevelProgression();

        ControllerPlayer.Instance.ResetControllerParentToPlatform();

        Destroy(m_currentGameObject);

        ManagerGameValue.Instance.ClearObstacleList();
        m_currentGameObject = GetRandomLevel();

        ControllerPlayer.Instance.ResetControllerParentToPlatform();

        GameCore.ManagerInput.Instance.DisableInputTemporary();
    }
    
    public GameObject GetRandomLevel() { return Instantiate(sz_m_gameObject[Random.Range(0, sz_m_gameObject.Length)]); }

    public void UpdateLevelNumber() {
        i32_levelCurrent++;
        i32_levelNext++;

        if (i32_levelCurrent >= 3) i32_levelCurrent = 3;
        if (i32_levelNext >= 3) i32_levelNext = 3;

        GUIManager.Instance.UpdateGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE.LEVEL_CURRENT);
        GUIManager.Instance.UpdateGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE.LEVEL_NEXT);
    }

    public void IncreaseLevelProgression() {
        i32_levelProgression++;

        if (i32_levelProgression >= 2) { 
            i32_levelProgression = 0;
            GUIManager.Instance.UpdateGUIElementSlider(ENUM_GUIELEMENT_SLIDER_TYPE.LEVEL_PROGRESSION);

            UpdateLevelNumber();
            DecreaseLevelRemaining();
        }

        GUIManager.Instance.UpdateGUIElementSlider(ENUM_GUIELEMENT_SLIDER_TYPE.LEVEL_PROGRESSION);
    }

    public void DecreaseLevelRemaining() {
        i32_levelRemaining--;
        if (i32_levelRemaining <= 0) ManagerGame.Instance.SetGameOverStatus(true, ENUM_GAMEOVER_TYPE.WIN);
    }

}
