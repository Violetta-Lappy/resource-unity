using System;
using UltEvents;
using UnityEngine;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New GuiBehaviorText-Something", menuName = "VLGameProject/Gui/New GuiBehaviorText-Something")]
    public abstract class SOABSGuiTextBehavior : ScriptableObject {
        [Header("Variable")]
        public GuiText m_guiText;
        public GuiText Get_GuiText() { return m_guiText; }
        public SOABSGuiTextBehavior Set_GuiText(GuiText arg_guiText) { 
            m_guiText = arg_guiText;
            return this;
        }
        public string str_format = "{0}";
        public string Get_Format() {
            return str_format;
        }
        public SOABSGuiTextBehavior Set_Format(string arg_format) {
            str_format = arg_format;
            return this;
        }

        public abstract void GuiBehaviorText_Init(); //TODO - REMOVE NONUSEABLE
        /// <summary>
        /// Sent when the mouse enters an element or one of its descendants.
        /// </summary>
        public abstract void GuiBehaviorText_OnPointerEnter();
        /// <summary>
        /// Sent when the pointer enters a visual element.
        /// </summary>
        public abstract void GuiBehaviorText_OnPointerHover();
        /// <summary>
        /// Sent when the pointer leaves a visual element and all of its descendants.
        /// </summary>
        public abstract void GuiBehaviorText_OnPointerExit();
        /// <summary>
        /// Sent when the user presses a mouse button
        /// </summary>
        public abstract void GuiBehaviorText_OnMouseDown();
        /// <summary>
        /// Sent when the user hold a mouse button.
        /// </summary>
        public abstract void GuiBehaviorText_OnMouseHold();
        /// <summary>
        /// Sent when the user releases a mouse button.
        /// </summary>
        public abstract void GuiBehaviorText_OnMouseRelease();
        /// <summary>
        /// Sent when the user hold and move around.
        /// </summary>
        public abstract void GuiBehaviorText_OnMouseMove(); //TODO: remember to implement
        /// <summary>
        /// Sent when the user activates the mouse wheel.
        /// </summary>
        public abstract void GuiBehaviorText_OnMouseWheel(); //TODO: remember to implement
        /// <summary>
        /// Sent when user change the text.
        /// </summary>
        public abstract void GuiBehaviorText_OnTextChange(string arg_text); //TODO: remember to implement
    }
}
