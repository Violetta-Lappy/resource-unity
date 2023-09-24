using TMPro;
using UnityEngine;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New GuiCustomization", menuName = "VLGameProject/Gui/New GuiCustomization")]
    public class SOGuiCustomization : ScriptableObject {
        [Header(nameof(GuiButton))]
        public TMP_FontAsset m_guiElementButtonFont;
        public float f_guiButtonFontSize;
        public SOGuiCustomization Set_GuiButtonFontSize(float arg_value) {
            f_guiButtonFontSize = arg_value;
            return this;
        }
        public Sprite m_buttonSprite;

        public Color m_disableColor;
        public SOGuiCustomization Set_DisableColor(Color arg_color) {
            m_disableColor = arg_color;
            return this;
        }
        public Color m_highlightColor;
        public SOGuiCustomization Set_HighlightColor(Color arg_color) {
            m_highlightColor = arg_color;
            return this;
        }

        [Header(nameof(GuiText))]
        public Color m_guiTextColor;
        public float f_guiTextTransformWidth;
        public SOGuiCustomization Set_GuiTextTransformWidth(float arg_value) {
            f_guiTextTransformWidth = arg_value;
            return this;
        }
        public float f_guiTextTransformHeight;
        public SOGuiCustomization Set_GuiTextTransformHeight(float arg_value) {
            f_guiTextTransformHeight = arg_value;
            return this;
        }
        public TMP_FontAsset m_guiElementTextFont;

        public float f_guiTextFontSize;
        public SOGuiCustomization Set_GuiTextFontSize(float arg_value) {
            f_guiTextFontSize = arg_value;
            return this;
        }
        public float Get_GuiTextFontSize() { return f_guiTextFontSize; }

        public float m_guiElementTextWidth;
        public float m_guiElementTextHeight;

        public bool isWrap;
        public bool isOverflow;

        [Header(nameof(GuiSlider))]
        public TMP_FontAsset m_guiElementSliderFont;
        public float f_guiSliderFontSize;
        public SOGuiCustomization Set_GuiSliderFontSize(float arg_value) {
            f_guiSliderFontSize = arg_value;
            return this;
        }        

        [Header(nameof(GuiDropdown))]
        public TMP_FontAsset m_guiElementDropdownFont;
        public float f_guiDropdownFontSize;
        public SOGuiCustomization Set_GuiDropdownFontSize(float arg_value) {
            f_guiDropdownFontSize = arg_value;
            return this;
        }

        private void Reset() {
            this
                .Set_GuiButtonFontSize(32) //GuiButton
                .Set_DisableColor(Color.white)
                .Set_HighlightColor(Color.white)
                .Set_GuiTextTransformWidth(256) //GuiText
                .Set_GuiTextTransformHeight(64)
                .Set_GuiTextFontSize(32)
                .Set_GuiSliderFontSize(32) //GuiSlider
                .Set_GuiDropdownFontSize(32); //GuiDropdown
        }
    }
}
