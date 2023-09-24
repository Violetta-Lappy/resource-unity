using UnityEngine;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New AudioMixerVoice", menuName = "VLGameProject/Gui/GuiBehaviorText/New AudioMixerVoice")]
    public class GBT_AudioMixerVoice : SOABSGuiTextBehavior {
        
        public override void GuiBehaviorText_Init() {
            //VLGuiEventListener.Instance().GuiText_OnAudioMixerSfx += GuiBehaviorText_OnTextChange;
        }

        public override void GuiBehaviorText_OnMouseDown() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorText_OnMouseHold() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorText_OnMouseMove() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorText_OnMouseRelease() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorText_OnMouseWheel() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorText_OnPointerEnter() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorText_OnPointerExit() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorText_OnPointerHover() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorText_OnTextChange(string arg_text) {
            throw new System.NotImplementedException();
        }
    }
}
