using UnityEngine;
using VLGameProject.VLSceneManagement;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New FunctionLoadSceneCurrent", menuName = "VLGameProject/Gui/GuiBehaviorButton/FunctionLoadSceneCurrent")]
    public class GBB_FunctionLoadSceneCurrent : SOABSGuiButtonBehavior {
        public override void GuiBehaviorButton_Init() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnMouseDown() {
            VLSceneTool.Load_CurrentScene_AutoBuildIndex();
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