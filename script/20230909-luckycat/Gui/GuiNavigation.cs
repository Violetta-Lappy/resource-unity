using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGui {
    public abstract class ABSGuiNavigation : GameProgramObject {
        public int i32_id;
        public abstract void GuiNavigation_MoveUp();
        public abstract void GuiNavigation_MoveDown();
        public abstract void GuiNavigation_MoveLeft();
        public abstract void GuiNavigation_MoveRight();
        public abstract void GuiNavigation_Forward();
        public abstract void GuiNavigation_Back();
    }

    public class GuiNavigation : ABSGuiNavigation {
        public override void GuiNavigation_MoveUp() {
            throw new System.NotImplementedException();
        }

        public override void GuiNavigation_MoveDown() {
            throw new System.NotImplementedException();
        }

        public override void GuiNavigation_MoveLeft() {
            throw new System.NotImplementedException();
        }

        public override void GuiNavigation_MoveRight() {
            throw new System.NotImplementedException();
        }

        public override void GuiNavigation_Forward() {
            throw new System.NotImplementedException();
        }

        public override void GuiNavigation_Back() {
            throw new System.NotImplementedException();
        }
    }
}

