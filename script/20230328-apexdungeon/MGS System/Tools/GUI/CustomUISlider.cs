using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added library
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CustomUISlider : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ENUM_UI_SLIDER_TYPE sliderType = ENUM_UI_SLIDER_TYPE.NONE;
    public Slider sampleSlider;    
    private bool isMouseHover = false;    

    public void Setup()
    {
        sampleSlider = this.GetComponent<Slider>();        

        //Call the GUIManager to setup this slide correctly
        GUIManager.Instance.SliderCreatorManager(sliderType, this, false);

        sampleSlider.onValueChanged.AddListener(delegate { GUIManager.Instance.SliderOnValueChangeManager(sliderType, this, false); });
    }

    private void Update() 
    {
        if (isMouseHover)
        {
            if (ProjectConstants.ENABLE_SYSFUNCTION_UI_HOVER_UPDATE)
                GUIManager.Instance.UISliderButtonManager(ENUM_UI_ELEMENTS_STATUS.HOVER_UPDATE);
        }        
    }

    public void SetupSlider(float min, float max, float defaultValue, bool isWholeNumber = false)
    {
        sampleSlider.wholeNumbers = isWholeNumber;
        sampleSlider.minValue = min;
        sampleSlider.maxValue = max;
        sampleSlider.value = defaultValue;
    }    

    public float Get_SliderValue()
    {
        return sampleSlider.value;
    }    

    public void SetActive(bool status)
    {
        this.transform.gameObject.SetActive(status);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_MOUSE_CLICK_ONCE)
            GUIManager.Instance.UISliderButtonManager(ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONCE);
    }

    //Detect current clicks on the GameObject (the one with the script attached)    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_MOUSE_CLICK_ONGOING)
            GUIManager.Instance.UISliderButtonManager(ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONGOING);
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_RELEASE)
            GUIManager.Instance.UISliderButtonManager(ENUM_UI_ELEMENTS_STATUS.MOUSE_RELEASE);
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Mouse hover detected
        isMouseHover = true;

        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_ENTER)
            GUIManager.Instance.UISliderButtonManager(ENUM_UI_ELEMENTS_STATUS.ENTER);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
        //Disable mouse hover function
        isMouseHover = false;

        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_EXIT)
            GUIManager.Instance.UISliderButtonManager(ENUM_UI_ELEMENTS_STATUS.EXIT);
    }
}
