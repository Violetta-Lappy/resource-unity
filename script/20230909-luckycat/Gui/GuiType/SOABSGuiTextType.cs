using UnityEngine;

namespace VLGameProject.VLGui {
    public abstract class SOABSGuiTextType : ScriptableObject {
        public string Get_Guid(ENUMGuiText arg_type) { return "EXAMPLE"; }
        public bool IsGuiTextType(ENUMGuiText arg_type) { return arg_type == Get_GuiTextType(); }
        public abstract ENUMGuiText Get_GuiTextType();
    }

    [CreateAssetMenu(fileName = "New Example", menuName = "VLGameProject/GuiTextType/New Example")]
    public class GuiTextType_Example : SOABSGuiTextType {
        public override ENUMGuiText Get_GuiTextType() {
            return ENUMGuiText.K_None;
        }
    }
}
