using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
using UnityEngine.EventSystems;

public class CustomUIButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ENUM_UI_BUTTON_TYPE uiButtonType = ENUM_UI_BUTTON_TYPE.EXAMPLE_TEST;    

    private bool isMouseHover = false;    

    public void Setup()
    {
        
    }

    private void Update()
    {
        if (isMouseHover)
        {
            if (ProjectConstants.ENABLE_SYSFUNCTION_UI_HOVER_UPDATE)
                GUIManager.Instance.UIButtonManager(this, uiButtonType, ENUM_UI_ELEMENTS_STATUS.HOVER_UPDATE);
        }
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData eventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_MOUSE_CLICK_ONCE)
        {                        
            GUIManager.Instance.UIButtonManager(this, uiButtonType, ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONCE);
        }            
    }

    //Detect current clicks on the GameObject (the one with the script attached)    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_MOUSE_CLICK_ONGOING)
            GUIManager.Instance.UIButtonManager(this, uiButtonType, ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONGOING);
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_RELEASE)
            GUIManager.Instance.UIButtonManager(this, uiButtonType, ENUM_UI_ELEMENTS_STATUS.MOUSE_RELEASE);
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Mouse hover detected
        isMouseHover = true;

        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_ENTER)
            GUIManager.Instance.UIButtonManager(this, uiButtonType, ENUM_UI_ELEMENTS_STATUS.ENTER);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
        //Disable mouse hover function
        isMouseHover = false;

        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_EXIT)
            GUIManager.Instance.UIButtonManager(this, uiButtonType, ENUM_UI_ELEMENTS_STATUS.EXIT);
    }

    public CustomUIValues Get_CustomUIValue()
    {
        return this.transform.GetComponentInParent<CustomUIValues>();
    }
}
