using UnityEngine;
using VLGameProject.VLSceneManagement;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New FunctionLoadSceneSplashScreen", menuName = "VLGameProject/Gui/GuiBehaviorButton/FunctionLoadSceneSplashScreen")]
    public class GBB_FunctionLoadSceneSplashScreen : SOABSGuiButtonBehavior {
        public override void GuiBehaviorButton_Init() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnMouseDown() {
            VLSceneTool.Instance().Load_Async_Scene_Specific(ENUM_SCENE.K_SPLASH_SCREEN);
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