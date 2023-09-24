using UnityEngine;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New FunctionExitToOS", menuName = "VLGameProject/Gui/GuiBehaviorButton/FunctionExitToOS")]
    public class GBB_FunctionExitToOS : SOABSGuiButtonBehavior {
        public override void GuiBehaviorButton_Init() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnMouseDown() {
            if (Application.platform != RuntimePlatform.WebGLPlayer) {
                Application.Quit();
                return;
            }
        }

        public override void GuiBehaviorButton_OnMouseHold() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnMouseMove() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnMouseRelease() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnMouseWheel() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnPointerEnter() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnPointerExit() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnPointerHover() {
            throw new System.NotImplementedException();
        }
    }
}