using UnityEngine;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New AudioMixerMaster", menuName = "VLGameProject/Gui/GuiBehaviorSlider/New AudioMixerMaster")]
    public class GBS_AudioMixerMaster : SOABSGuiSliderBehavior {
        public override void GuiBehaviorSlider_Init() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnMouseDown() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnMouseHold() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnMouseMove() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnMouseRelease() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnMouseWheel() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnPointerEnter() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnPointerExit() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnPointerHover() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorSlider_OnSliderValueChange() {
            VLGuiEventListener.Instance().UpdateText_AudioMixerMaster(null);
        }
    }
}
