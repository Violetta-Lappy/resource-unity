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
using UnityEngine.EventSystems;

namespace VLGameProject.VLGui {
    public class GuiButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
        public GuiManager m_guiManager;
        public ENUM_GUIELEMENT_BUTTON enum_type;
        public bool isMouseHover;
        public void Set_GuiManager(GuiManager _guiManager) => m_guiManager = _guiManager;
        public bool Is_GuiElementButton_Type(ENUM_GUIELEMENT_BUTTON _type) { return _type == enum_type; }
        public ENUM_GUIELEMENT_BUTTON Get_GuiElementButton_Type() { return enum_type; }

        private void Update() {
            if (IsMouseHover() && GuiSetting.K_EnablePointerOnMouseHover) {
                m_guiManager.On_GuiElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_HOLD);
            }
        }

        public bool IsMouseHover() { return isMouseHover; }
        public void Set_IsMouseHover(bool _status) { isMouseHover = _status; }

        public void OnPointerClick(PointerEventData eventData) {
            if (GuiSetting.K_EnablePointerOnMouseDown == false) return; //Check-functionality
            m_guiManager.On_GuiElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_DOWN);
        }

        public void OnPointerEnter(PointerEventData eventData) {
            if (GuiSetting.K_EnablePointerOnMouseEnter == false) return; //Check-functionality
            Set_IsMouseHover(true);
            m_guiManager.On_GuiElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER.K_ON_ENTER);
        }

        public void OnPointerExit(PointerEventData eventData) {
            if (GuiSetting.K_EnablePointerOnMouseExit == false) return; //Check-functionality        
            Set_IsMouseHover(false);
            m_guiManager.On_GuiElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER.K_ON_EXIT);
        }

        public void OnPointerDown(PointerEventData eventData) {
            if (GuiSetting.K_EnablePointerOnMouseHold == false) return; //Check-functionality
            m_guiManager.On_GuiElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_HOLD);
        }

        public void OnPointerUp(PointerEventData eventData) {
            if (GuiSetting.K_EnablePointerOnMouseRelease == false) return; //Check-functionality
            m_guiManager.On_GuiElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_RELEASE);
        }
    }
}
