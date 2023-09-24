using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIElementButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    public ENUM_GUIELEMENT_BUTTON_TYPE enum_buttonType = ENUM_GUIELEMENT_BUTTON_TYPE.NONE;    

    public void OnPointerClick(PointerEventData eventData) {
        if (GUISettings.K_IS_ACTIVE_ON_MOUSE_DOWN == false) return; //Check-functionality
        GUIManager.Instance.DoGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN);
    }        

    public void OnPointerEnter(PointerEventData eventData) {
        if (GUISettings.K_IS_ACTIVE_ON_ENTER == false) return; //Check-functionality        
        GUIManager.Instance.DoGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (GUISettings.K_IS_ACTIVE_ON_EXIT == false) return; //Check-functionality        
        GUIManager.Instance.DoGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT);
    }
}
