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

using UnityEngine;

namespace VLGameProject.VLGui {
    public class GuiElementObject : MonoBehaviour {
        [SerializeField] private GuiManager m_guiManager;
        [SerializeField] private ENUM_GUIELEMENT_OBJECT enum_type;
        public void Set_GuiManager(GuiManager _guiManager) => m_guiManager = _guiManager;
        public bool Is_GuiElementObject_Type(ENUM_GUIELEMENT_OBJECT _type) { return _type == enum_type; }
        public ENUM_GUIELEMENT_OBJECT Get_GuiElementObject_Type() { return enum_type; }
        public bool Is_GuiElementObject_Active() { return this.gameObject.activeInHierarchy; }
        public void Set_Status_GuiElementObject_Active(bool _status) { this.gameObject.SetActive(_status); }
    }
}

