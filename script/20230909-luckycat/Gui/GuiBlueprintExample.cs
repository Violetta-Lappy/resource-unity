using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGui {
    /// <summary>
    /// Usage for GuiPopulate
    /// </summary>
    public class GuiBlueprintExample : ABSGuiBlueprint {
        public override void GuiBlueprint_Start() {
            throw new System.NotImplementedException();
        }
        public override void GuiBlueprint_Loop() {
            throw new System.NotImplementedException();
        }
        public override void GuiBlueprint_End() {
            throw new System.NotImplementedException();
        }
    }

    public abstract class ABSGuiBlueprint : GameProgramObject {
        public abstract void GuiBlueprint_Start();
        public abstract void GuiBlueprint_Loop();
        public abstract void GuiBlueprint_End();
    }
}
