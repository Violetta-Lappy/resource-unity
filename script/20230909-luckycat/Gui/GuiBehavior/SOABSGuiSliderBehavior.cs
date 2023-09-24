using UltEvents;
using UnityEngine;

namespace VLGameProject.VLGui {    
    public abstract class SOABSGuiSliderBehavior : ScriptableObject {        
        [Header("Variable")]
        //public ProgramValue m_sliderValue;
        //Could use programvalue but decide to simplyfied the process        
        public float f_value;
        public SOABSGuiSliderBehavior Set_Value(float arg_value) {
            f_value = arg_value;
            return this;
        }
        public float f_valueMin;
        public SOABSGuiSliderBehavior Set_ValueMin(float arg_value) {
            f_valueMin = arg_value;
            return this;
        }
        public float f_valueMax;
        public SOABSGuiSliderBehavior Set_ValueMax(float arg_value) {
            f_valueMax = arg_value;
            return this;
        }
        public float f_step;
        public SOABSGuiSliderBehavior Set_Step(float arg_value) {
            f_step = arg_value;
            return this;
        }

        private void Reset() {
            Set_Value(0)
                .Set_ValueMin(0)
                .Set_ValueMax(1)
                .Set_Step(0);
        }

        public abstract void GuiBehaviorSlider_Init();
        /// <summary>
        /// Sent when the mouse enters an element or one of its descendants.
        /// </summary>
        public abstract void GuiBehaviorSlider_OnPointerEnter();
        /// <summary>
        /// Sent when the pointer enters a visual element.
        /// </summary>
        public abstract void GuiBehaviorSlider_OnPointerHover();
        /// <summary>
        /// Sent when the pointer leaves a visual element and all of its descendants.
        /// </summary>
        public abstract void GuiBehaviorSlider_OnPointerExit();
        /// <summary>
        /// Sent when the user presses a mouse button
        /// </summary>
        public abstract void GuiBehaviorSlider_OnMouseDown();
        /// <summary>
        /// Sent when the user hold a mouse button.
        /// </summary>
        public abstract void GuiBehaviorSlider_OnMouseHold();
        /// <summary>
        /// Sent when the user releases a mouse button.
        /// </summary>
        public abstract void GuiBehaviorSlider_OnMouseRelease();
        /// <summary>
        /// Sent when the user hold and move around.
        /// </summary>
        public abstract void GuiBehaviorSlider_OnMouseMove(); //TODO: remember to implement
        /// <summary>
        /// Sent when the user activates the mouse wheel.
        /// </summary>
        public abstract void GuiBehaviorSlider_OnMouseWheel(); //TODO: remember to implement
        /// <summary>
        /// Sent when the user change value in slider.
        /// </summary>
        public abstract void GuiBehaviorSlider_OnSliderValueChange(); //TODO: remember to implement
    }
}
