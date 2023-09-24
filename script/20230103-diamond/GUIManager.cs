/**
 * author: hoanglongplanner
 * date: Jan 2th 2022
 * des: Managing all type of GUI in game, use Singleton Design Pattern
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUISettings {    
    public static bool K_IS_ACTIVE_ON_MOUSE_DOWN = true; //def: true    
    public static bool K_IS_ACTIVE_ON_ENTER = true; //def: true    
    public static bool K_IS_ACTIVE_ON_EXIT = true; //def: true
}

public enum ENUM_GUIELEMENT_POINTER_STATUS {
    ON_MOUSE_DOWN,    
    ON_ENTER,    
    ON_EXIT
}

public enum ENUM_GUIELEMENT_OBJECT_TYPE {
    NONE, //default
    IN_PROGRESS_GAME
}

public enum ENUM_GUIELEMENT_BUTTON_TYPE {
    NONE, //default
    FUNCTION_LOADSCENE_MAINMENU,
    FUNCTION_LOADSCENE_GAMEPLAY,
    FUNCTION_BOARD_RESHUFFLE,    
    FUNCTION_EXITGAME
}

public enum ENUM_GUIELEMENT_TEXT_TYPE {
    NONE, //default
    HIGHSCORE,
    TIMER,
    MOVES
}

public class GUIManager : SingletonBlank<GUIManager> {

    public List<GUIElementObject> m_list_guiObject;
    public List<GUIElementText> m_list_guiText;
    public List<GUIElementButton> m_list_guiButton;

    public override void SingletonAwake() { SetupGUIManager(this.transform, true); }

    public void SetupGUIManager(Transform targetTransform = null, bool isItself = false) {
        if (isItself) targetTransform = this.transform;
        if (targetTransform == null) return; //early-exit

        foreach (Transform item in targetTransform) {
            CheckGUIElementLists(item);
            if (item.childCount > 0) SetupGUIManager(item, false); //WARNING-RECCURSIVE            
        }
    }

    private void CheckGUIElementLists(Transform targetTransform) {        
        GUIElementObject guiObject = targetTransform.GetComponent<GUIElementObject>();
        if (guiObject != null) { m_list_guiObject.Add(guiObject); return; }

        GUIElementText guiText = targetTransform.GetComponent<GUIElementText>();
        if (guiText != null) { m_list_guiText.Add(guiText); guiText.Setup(); return; }

        GUIElementButton guiButton = targetTransform.GetComponent<GUIElementButton>();
        if (guiButton != null) { m_list_guiButton.Add(guiButton); return; }
    }

    public void DoGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE type, bool status) {
        foreach (GUIElementObject item in m_list_guiObject) {
            if (item.type != type) continue; //skip-if-not-correct-type
            OnGUIElementObject(item, type, status); //call-function
            item.gameObject.SetActive(status);
        }
    }

    private void OnGUIElementObject(GUIElementObject guiObject, ENUM_GUIELEMENT_OBJECT_TYPE type, bool status) {
        switch (type) {
            case ENUM_GUIELEMENT_OBJECT_TYPE.NONE:
                break;
            case ENUM_GUIELEMENT_OBJECT_TYPE.IN_PROGRESS_GAME:
                break;
            default:
                break;
        }
    }

    public void DoGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE type, string input) {
        foreach (GUIElementText item in m_list_guiText) {
            if (item.type != type) continue; //skip-if-not-correct-type                        
            item.SetText(OnGUIElementText(type, input));
        }
    }

    public string OnGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE type, string input) {
        string tempInput = input;
        switch (type) {
            case ENUM_GUIELEMENT_TEXT_TYPE.NONE:
                break;
            case ENUM_GUIELEMENT_TEXT_TYPE.HIGHSCORE:
                break;
            case ENUM_GUIELEMENT_TEXT_TYPE.TIMER:
                break;
            case ENUM_GUIELEMENT_TEXT_TYPE.MOVES:
                break;
            default:
                break;
        }

        return tempInput;
    }

    public void DoGUIElementButton(GUIElementButton guiButton, ENUM_GUIELEMENT_BUTTON_TYPE buttonType, ENUM_GUIELEMENT_POINTER_STATUS status) {
        switch (status) {
            case ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN:
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);

                switch (buttonType) {
                    case ENUM_GUIELEMENT_BUTTON_TYPE.NONE:
                        break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_LOADSCENE_MAINMENU:
                        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                        break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_LOADSCENE_GAMEPLAY:
                        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                        break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_BOARD_RESHUFFLE:
                        ManagerMatch3.Instance.DoGameBoardShuffle();
                        break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_EXITGAME:
                        if(Application.platform != RuntimePlatform.WebGLPlayer) Application.Quit();
                        break;
                    default:
                        break;
                }

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
}
