using UnityEngine;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New AudioMixerMaster", menuName = "VLGameProject/Gui/GuiBehaviorText/New AudioMixerMaster")]
    public class GBT_AudioMixerMaster : SOABSGuiTextBehavior {

        private void Reset() {
            Set_Format("{0}");
        }

        public override void GuiBehaviorText_Init() {            
            VLGuiEventListener.Instance().GuiText_OnAudioMixerMaster += GuiBehaviorText_OnTextChange;
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
            var text = string.Format(Get_Format(), arg_text);
            Get_GuiText().Set_Text(text);
        }
    }
}
