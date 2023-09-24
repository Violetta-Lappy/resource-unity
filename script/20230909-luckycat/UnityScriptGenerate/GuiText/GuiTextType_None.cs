using UnityEngine;
namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New None", menuName = "VLGameProject/GuiTextType/New None")]
    public class GuiTextType_None : SOABSGuiTextType {
        public override ENUMGuiText Get_GuiTextType() {
            return ENUMGuiText.K_None;
        }
    }
}

