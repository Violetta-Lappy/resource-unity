using UltEvents;
using UnityEngine;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New GuiBehaviorDropdown-Something", menuName = "VLGameProject/Gui/New GuiBehaviorDropdown-Something")]
    public abstract class SOABSGuiDropdownBehavior : ScriptableObject {        
        /// <summary>
        /// Sent when dropdown component Monobehavior Reset start.
        /// </summary>
        public abstract void GuiDropdownBehavior_EditorReset(GuiDropdown arg_dropdown);
        /// <summary>
        /// Sent when dropdown component Monobehavior start.
        /// </summary>
        public abstract void GuiDropdownBehavior_Init();
        /// <summary>
        /// Sent when the mouse enters an element or one of its descendants.
        /// </summary>
        public abstract void GuiDropdownBehavior_OnPointerEnter();
        /// <summary>
        /// Sent when the pointer enters a visual element.
        /// </summary>
        public abstract void GuiDropdownBehavior_OnPointerHover();
        /// <summary>
        /// Sent when the pointer leaves a visual element and all of its descendants.
        /// </summary>
        public abstract void GuiDropdownBehavior_OnPointerExit();
        /// <summary>
        /// Sent when the user presses a mouse button
        /// </summary>
        public abstract void GuiDropdownBehavior_OnMouseDown();
        /// <summary>
        /// Sent when the user hold a mouse button.
        /// </summary>
        public abstract void GuiDropdownBehavior_OnMouseHold();
        /// <summary>
        /// Sent when the user releases a mouse button.
        /// </summary>
        public abstract void GuiDropdownBehavior_OnMouseRelease();
        /// <summary>
        /// Sent when the user hold and move around.
        /// </summary>
        public abstract void GuiDropdownBehavior_OnMouseMove(); //TODO: remember to implement
        /// <summary>
        /// Sent when the user hold and move around.
        /// </summary>
        public abstract void GuiDropdownBehavior_OnMouseDrag(); //TODO: remember to implement
        /// <summary>
        /// Sent when the user activates the mouse wheel.
        /// </summary>
        public abstract void GuiDropdownBehavior_OnMouseWheel(); //TODO: remember to implement
        /// <summary>
        /// Sent when the user select an item in dropdown
        /// </summary>
        public abstract void GuiDropdownBehavior_OnDropdownItemSelect();
    }
}
