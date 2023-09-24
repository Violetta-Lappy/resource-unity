using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Currency_Crystal", menuName = "VLGameProject/GuiTextType/New Currency_Crystal")]
public class GuiTextType_Currency_Crystal : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_Currency_Crystal;
}
}
}

