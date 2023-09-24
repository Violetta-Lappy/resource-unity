using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLSceneManagement;

namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New FunctionLoadSceneMainMenu", menuName = "VLGameProject/Gui/GuiBehaviorButton/FunctionLoadSceneMainMenu")]
    public class GBB_FunctionLoadSceneMainMenu : SOABSGuiButtonBehavior {
        public override void GuiBehaviorButton_Init() {
            throw new System.NotImplementedException();
        }

        public override void GuiBehaviorButton_OnMouseDown() {
            VLSceneTool.Instance().Load_Async_Scene_Specific(ENUM_SCENE.K_MAIN_MENU);
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