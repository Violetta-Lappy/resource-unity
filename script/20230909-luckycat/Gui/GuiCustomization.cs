using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLGui {

    [System.Serializable]
    public class GuiCustomizationSetting {
        public bool isUsingGuiSkinSetting;
    }

    //Based on Unity Tutorial - GuiSkin
    public class GuiCustomization : MonoBehaviour {
        public GuiCustomizationSetting m_guiCustomizationSetting;
        public SOGuiCustomization m_guiCustomization;
        public SOGuiCustomization Get_GuiCustomization() { return m_guiCustomization; }
        private void OnValidate() {
            if (Get_GuiCustomization() != null) {
                return; //early-exit
            }
            else {
                if (this.gameObject.GetComponent<GuiText>() != null) {
                    var guiElementText = this.gameObject.GetComponent<GuiText>();
                    guiElementText.Set_FontSize(Get_GuiCustomization().Get_GuiTextFontSize());
                }
                if (this.gameObject.GetComponent<GuiButton>() != null) {

                }
                if (this.gameObject.GetComponent<GuiSlider>() != null) {

                }
                if (this.gameObject.GetComponent<GuiDropdown>() != null) {

                }
            }
        }
    }
}
