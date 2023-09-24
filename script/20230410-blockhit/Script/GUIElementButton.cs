using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIElementButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private ENUM_GUIELEMENT_BUTTON_TYPE enum_buttonType;

    public bool IsType(ENUM_GUIELEMENT_BUTTON_TYPE _type) { return _type == enum_buttonType; }

    public void OnPointerClick(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_ON_MOUSE_DOWN == false) return; //Check-functionality
        GUIManager.Instance.OnGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN);
    }        

    public void OnPointerEnter(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_ON_ENTER == false) return; //Check-functionality        
        GUIManager.Instance.OnGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_ON_EXIT == false) return; //Check-functionality        
        GUIManager.Instance.OnGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT);
    }
}
