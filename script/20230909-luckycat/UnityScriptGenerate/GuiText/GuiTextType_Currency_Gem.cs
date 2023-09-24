using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Currency_Gem", menuName = "VLGameProject/GuiTextType/New Currency_Gem")]
public class GuiTextType_Currency_Gem : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_Currency_Gem;
}
}
}

