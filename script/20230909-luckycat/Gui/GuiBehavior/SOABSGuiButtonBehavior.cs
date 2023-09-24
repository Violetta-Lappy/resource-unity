using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

namespace VLGameProject.VLGui {    
    public abstract class SOABSGuiButtonBehavior : ScriptableObject {        
        public abstract void GuiBehaviorButton_Init();
        /// <summary>
        /// Sent when the mouse enters an element or one of its descendants.
        /// </summary>
        public abstract void GuiBehaviorButton_OnPointerEnter();
        /// <summary>
        /// Sent when the pointer enters a visual element.
        /// </summary>
        public abstract void GuiBehaviorButton_OnPointerHover();
        /// <summary>
        /// Sent when the pointer leaves a visual element and all of its descendants.
        /// </summary>
        public abstract void GuiBehaviorButton_OnPointerExit();
        /// <summary>
        /// Sent when the user presses a mouse button
        /// </summary>
        public abstract void GuiBehaviorButton_OnMouseDown();
        /// <summary>
        /// Sent when the user hold a mouse button.
        /// </summary>
        public abstract void GuiBehaviorButton_OnMouseHold();
        /// <summary>
        /// Sent when the user releases a mouse button.
        /// </summary>
        public abstract void GuiBehaviorButton_OnMouseRelease();
        /// <summary>
        /// Sent when the user hold and move around.
        /// </summary>
        public abstract void GuiBehaviorButton_OnMouseMove(); //TODO: remember to implement
        /// <summary>
        /// Sent when the user activates the mouse wheel.
        /// </summary>
        public abstract void GuiBehaviorButton_OnMouseWheel(); //TODO: remember to implement
    }
}
