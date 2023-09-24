using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Currency_Penny", menuName = "VLGameProject/GuiTextType/New Currency_Penny")]
public class GuiTextType_Currency_Penny : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_Currency_Penny;
}
}
}

