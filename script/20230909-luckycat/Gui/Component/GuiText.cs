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
    public class GuiText : MonoBehaviour {
        [Header("GuiBehaviorText")]
        public SOABSGuiTextType m_guiTextType;
        public SOABSGuiTextType Get_GuiTextType() { return m_guiTextType; }
        public SOABSGuiTextBehavior m_guiBehaviorText;
        public SOABSGuiTextBehavior Get_GuiBehaviorText() { return m_guiBehaviorText; }

        [Header("GuiManager")]
        public GuiManager m_guiManager;        
        public TMPro.TextMeshProUGUI m_tmpro;

        private void Reset() {
            m_tmpro = this.GetComponent<TMPro.TextMeshProUGUI>();
        }

        private void Start() {
            Get_GuiBehaviorText().Set_GuiText(this);
            Get_GuiBehaviorText().GuiBehaviorText_Init();            
        }

        public void Set_GuiManager(GuiManager arg_guiManager) => m_guiManager = arg_guiManager;        
        
        public GuiText Set_Text(string arg_text) {
            m_tmpro.text = arg_text;
            return this;
        }

        public GuiText Set_FontSize(float arg_value) {
            m_tmpro.fontSize = arg_value;
            return this;
        }
    }
}

