/*
Copyright 2023 hoanglongplanner 

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.

You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added library
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using UltEvents;
using VLGameProject.VLGui;

namespace VLGameProject.VLGui {
    public class GuiSlider : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {        
        [Header("Setting")]
        public GuiManager m_guiManager;
        public ENUM_GUIELEMENT_SLIDER enum_type;
        public Slider m_slider;
        public bool isMouseHover = false;

        public void SetGUIManager(GuiManager _guiManager) => m_guiManager = _guiManager;

        public void Setup() {
            m_slider = this.GetComponent<Slider>();
            //m_slider.onValueChanged.AddListener(delegate { m_guiManager.OnGUIElementSlider(this, enum_type); });
            //m_guiManager.OnGUIElementSlider(this, enum_type);
        }

        public void Setup_Slider(float min, float max, float defaultValue, bool isWholeNumber = false) {
            m_slider.wholeNumbers = isWholeNumber;
            m_slider.minValue = min;
            m_slider.maxValue = max;
            m_slider.value = defaultValue;
        }

        public bool Is_GuiElementSlider_Type(ENUM_GUIELEMENT_SLIDER _type) { return _type == enum_type; }
        public ENUM_GUIELEMENT_SLIDER Get_GuiElementSlider_Type() { return enum_type; }

        private void Update() {
            if (isMouseHover && GuiSetting.K_EnablePointerOnMouseHover) {
                //m_guiManager.GuiElementSlider_Manager(ENUM_GUIELEMENT_POINTER.K_ON_HOVER);
            }
        }

        public float Get_Value() { return m_slider.value; }
        public float Get_Value_Min() { return m_slider.minValue; }
        public float Get_Value_Max() { return m_slider.maxValue; }

        public void Set_Value(float _value) {
            m_slider.value = Mathf.Clamp(_value, Get_Value_Min(), Get_Value_Max());
            //OnSliderValueChange?.Invoke(Get_Value());
        }

        public void Set_Value_Min(float _value) {
            m_slider.minValue = Mathf.Clamp(_value, float.MinValue, Get_Value_Max());
            Set_Value(Get_Value()); //safe-check-current-value-in-new-range
            //OnSliderValueMinChange?.Invoke(Get_Value_Min());
        }

        public void Set_Value_Max(float _value) {
            m_slider.maxValue = Mathf.Clamp(_value, Get_Value_Min(), float.MaxValue);
            Set_Value(Get_Value()); //safe-check-current-value-in-new-range
            //OnSliderValueMaxChange?.Invoke(Get_Value_Max());
        }

        public void Set_Active(bool status) => this.transform.gameObject.SetActive(status);

        public void OnPointerClick(PointerEventData eventData) { 
           // m_guiManager.GuiElementSlider_Manager(ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_DOWN); 
        }

        public void OnPointerEnter(PointerEventData eventData) {
            isMouseHover = true;
            //m_guiManager.GuiElementSlider_Manager(ENUM_GUIELEMENT_POINTER.K_ON_ENTER);
        }

        public void OnPointerExit(PointerEventData eventData) {
            isMouseHover = false;
            //m_guiManager.GuiElementSlider_Manager(ENUM_GUIELEMENT_POINTER.K_ON_EXIT);
        }
    }
}

