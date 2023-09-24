using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLGui {
    public abstract class SOABSGuiPageType : ScriptableObject {        
        public string Get_Guid(ENUMGuiPage arg_type) { return "EXAMPLE"; }
        public bool IsGuiPageType(ENUMGuiPage arg_type) { return arg_type == Get_GuiPageType(); }
        public abstract ENUMGuiPage Get_GuiPageType();
    }

    [CreateAssetMenu(fileName = "New Example", menuName = "VLGameProject/GuiPage/New Example")]
    public class GuiPageType_Example : SOABSGuiPageType {
        public override ENUMGuiPage Get_GuiPageType() {
            return ENUMGuiPage.K_None;
        }
    }
}
