using UnityEngine;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New FunctionPauseGame", menuName = "VLGameProject/Gui/GuiBehaviorButton/FunctionPauseGame")]
    public class GBB_FunctionPauseGame : SOABSGuiButtonBehavior {
        public override void GuiBehaviorButton_Init() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnMouseDown() {
            //TODO - Add Logic that resume game
            //OpenGUIPage(ENUM_GUIPAGE.K_PAUSE_MENU);
            //GameProgram.Pause
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