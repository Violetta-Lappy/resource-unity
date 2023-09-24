/**
 * author: hoanglongplanner
 * date: Jan 2th 2022
 * des: Managing all type of GUI in game, use Singleton Design Pattern
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ENUM_SCENE {
    MAIN_MENU,
    NORMAL_GAMEMODE,
    TIMEATTACK_GAMEMODE
}

public class GUISettings {
    public static bool K_ENABLE_ON_MOUSE_DOWN = true; //def: true    
    public static bool K_ENABLE_ON_ENTER = true; //def: true    
    public static bool K_ENABLE_ON_EXIT = true; //def: true
}

public enum ENUM_GUIPAGE {
    WIN,
    LOSE
}

public enum ENUM_GUIELEMENT_POINTER_STATUS {
    ON_MOUSE_DOWN,
    ON_ENTER,
    ON_EXIT
}

public enum ENUM_GUIELEMENT_OBJECT_TYPE {
    TIMER,
    DISABLE_INPUT
}

public enum ENUM_GUIELEMENT_BUTTON_TYPE {
    FUNCTION_LOADSCENE_MAINMENU,
    FUNCTION_LOADSCENE_NORMAL_GAMEPLAY,
    FUNCTION_LOADSCENE_TIMEATTACK_GAMEPLAY,
    FUNCTION_RESTART_GAME,
    FUNCTION_EXITGAME
}

public enum ENUM_GUIELEMENT_TEXT_TYPE {
    HIGHSCORE,
    TIMER,
    COMBO,
    LEVEL_CURRENT,
    LEVEL_NEXT
}

public enum ENUM_GUIELEMENT_SLIDER_TYPE {
    FEVER,
    OBSTACLE_LEFT,
    LEVEL_PROGRESSION
}

public class GUIManager : SingletonBlank<GUIManager> {

    public GameObject[] sz_m_page;

    public List<GUIElementObject> list_m_guiObject;
    public List<GUIElementText> list_m_guiText;
    public List<GUIElementButton> list_m_guiButton;
    public List<GUIElementSlider> list_m_guiSlider;

    public override void SingletonAwake() => SetupGUIManager(this.transform, true);

    private void Start() => UpdateGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE.TIMER);

    public void OpenGUIPage(ENUM_GUIPAGE _type) {
        switch (_type) {
            case ENUM_GUIPAGE.WIN: sz_m_page[(int)ENUM_GUIPAGE.WIN].SetActive(true); break;
            case ENUM_GUIPAGE.LOSE: sz_m_page[(int)ENUM_GUIPAGE.LOSE].SetActive(true); break;
            default: break;
        }
    }

    public void SetupGUIManager(Transform targetTransform = null, bool isItself = false) {
        if (isItself) targetTransform = this.transform;
        if (targetTransform == null) return; //early-exit

        foreach (Transform item in targetTransform) {
            CheckGUIElement(item);
            if (item.childCount > 0) SetupGUIManager(item, false); //WARNING-RECCURSIVE            
        }
    }

    private void CheckGUIElement(Transform _target) {
        GUIElementObject guiObject = _target.GetComponent<GUIElementObject>();
        if (guiObject != null) list_m_guiObject.Add(guiObject);

        GUIElementText guiText = _target.GetComponent<GUIElementText>();
        if (guiText != null) { 
            list_m_guiText.Add(guiText);
            guiText.Setup();
        }

        GUIElementButton guiButton = _target.GetComponent<GUIElementButton>();
        if (guiButton != null) list_m_guiButton.Add(guiButton);

        GUIElementSlider guiSlider = _target.GetComponent<GUIElementSlider>();
        if (guiSlider != null) {
            list_m_guiSlider.Add(guiSlider);
            guiSlider.Setup();
        }
    }

    public List<GUIElementObject> GetAllGUIElementObjectOfType(ENUM_GUIELEMENT_OBJECT_TYPE _type) {
        List<GUIElementObject> temp = new List<GUIElementObject>();
        foreach (GUIElementObject guiObject in list_m_guiObject) {
            if (guiObject.IsType(_type))
                temp.Add(guiObject);
        }
        return temp; //return-result
    }

    public List<GUIElementText> GetAllGUIElementTextOfType(ENUM_GUIELEMENT_TEXT_TYPE _type) {
        List<GUIElementText> temp = new List<GUIElementText>();
        foreach (GUIElementText text in list_m_guiText) {
            if (text.IsType(_type))
                temp.Add(text);
        }
        return temp; //return-result
    }

    public List<GUIElementButton> GetAllGUIElementButtonOfType(ENUM_GUIELEMENT_BUTTON_TYPE _type) {
        List<GUIElementButton> temp = new List<GUIElementButton>();
        foreach (GUIElementButton button in list_m_guiButton) {
            if (button.IsType(_type))
                temp.Add(button);
        }
        return temp; //return-result
    }

    public List<GUIElementSlider> GetAllGUIElementSliderOfType(ENUM_GUIELEMENT_SLIDER_TYPE _type) {
        List<GUIElementSlider> temp = new List<GUIElementSlider>();
        foreach (GUIElementSlider slider in list_m_guiSlider) {
            if (slider.IsType(_type))
                temp.Add(slider);
        }
        return temp; //return-result
    }

    public void UpdateGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE _type) {
        List<GUIElementObject> objectList = GetAllGUIElementObjectOfType(_type);
        foreach (GUIElementObject _guiObject in objectList) {
            switch (_type) {
                case ENUM_GUIELEMENT_OBJECT_TYPE.TIMER:
                    //if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == (int)ENUM_SCENE.TIMEATTACK_GAMEMODE) _guiObject.gameObject.SetActive(true);
                    if (ManagerGame.Instance.IsGameMode(ENUM_GAMEMODE_TYPE.TIMEATTACK)) _guiObject.gameObject.SetActive(true);
                    else _guiObject.gameObject.SetActive(false);
                    break;
                case ENUM_GUIELEMENT_OBJECT_TYPE.DISABLE_INPUT:
                    _guiObject.gameObject.SetActive(!GameCore.ManagerInput.Instance.IsAllowInput());
                    break;
                default: break;
            }
        }
    }

    public void UpdateGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE _type) {
        List<GUIElementText> textList = GetAllGUIElementTextOfType(_type);
        foreach (GUIElementText text in textList) {
            switch (_type) {
                case ENUM_GUIELEMENT_TEXT_TYPE.HIGHSCORE: text.SetText("" + ManagerGameValue.Instance.GetValueHighScore()); break;
                case ENUM_GUIELEMENT_TEXT_TYPE.TIMER: text.SetText("Time Attack: " + ManagerGameValue.Instance.GetValueTimer()); break;
                case ENUM_GUIELEMENT_TEXT_TYPE.COMBO: text.SetText(ManagerGameValue.Instance.GetValueCombo() + "X Combos !!"); break;
                case ENUM_GUIELEMENT_TEXT_TYPE.LEVEL_CURRENT: text.SetText(FactoryLevel.Instance.GetValueLevelCurrent().ToString()); break;
                case ENUM_GUIELEMENT_TEXT_TYPE.LEVEL_NEXT: text.SetText(FactoryLevel.Instance.GetValueLevelNext().ToString()); break;
                default: break;
            }
        }
    }

    public void OnGUIElementButton(GUIElementButton _button, ENUM_GUIELEMENT_BUTTON_TYPE _buttonType, ENUM_GUIELEMENT_POINTER_STATUS _pointerStatus) {
        switch (_pointerStatus) {

            case ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN:
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);

                switch (_buttonType) {
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_LOADSCENE_MAINMENU: UnityEngine.SceneManagement.SceneManager.LoadScene((int)ENUM_SCENE.MAIN_MENU); break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_LOADSCENE_NORMAL_GAMEPLAY: UnityEngine.SceneManagement.SceneManager.LoadScene((int)ENUM_SCENE.NORMAL_GAMEMODE); break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_LOADSCENE_TIMEATTACK_GAMEPLAY: UnityEngine.SceneManagement.SceneManager.LoadScene((int)ENUM_SCENE.TIMEATTACK_GAMEMODE); break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_RESTART_GAME: LoadCurrentScene_AutoBuildIndex(); break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_EXITGAME:
                        Debug.Log("Exit Game !!");
                        if (Application.platform != RuntimePlatform.WebGLPlayer)
                            Application.Quit();
                        break;
                    default: break;
                }
                break;

            case ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER:
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.HOVER);
                break;

            case ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT:
                break;

            default: break;
        }
    }

    public void UpdateGUIElementSlider(ENUM_GUIELEMENT_SLIDER_TYPE _type) {
        List<GUIElementSlider> sliderList = GetAllGUIElementSliderOfType(_type);
        foreach (GUIElementSlider slider in sliderList) OnGUIElementSlider(slider, _type);
    }

    public void GUIElementSliderManager(ENUM_GUIELEMENT_POINTER_STATUS _pointerType) {
        switch (_pointerType) {
            case ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN:
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);
                break;
            case ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER:
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.HOVER);
                break;
            case ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT:
                break;
            default:
                break;
        }
    }

    public void OnGUIElementSlider(GUIElementSlider _slider, ENUM_GUIELEMENT_SLIDER_TYPE _type) {
        switch (_type) {
            case ENUM_GUIELEMENT_SLIDER_TYPE.FEVER:
                _slider.SetupSlider(0.0f, 100.0f, ManagerGameValue.Instance.GetValueFever(), false);
                break;
            case ENUM_GUIELEMENT_SLIDER_TYPE.OBSTACLE_LEFT: _slider.SetupSlider(0.0f, 100.0f, ManagerGameValue.Instance.GetValueObstacleLeft()); break;
            case ENUM_GUIELEMENT_SLIDER_TYPE.LEVEL_PROGRESSION:
                _slider.SetupSlider(0, 2, FactoryLevel.Instance.GetValueLevelProgression(), true);
                break;
            default: break;
        }
    }

    private void LoadCurrentScene_AutoBuildIndex() => UnityEngine.SceneManagement.SceneManager.LoadScene(GetCurrentSceneBuildID());

    private int GetCurrentSceneBuildID() { return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; }
}
