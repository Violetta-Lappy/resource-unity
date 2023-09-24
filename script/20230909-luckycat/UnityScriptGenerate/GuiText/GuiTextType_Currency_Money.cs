using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Currency_Money", menuName = "VLGameProject/GuiTextType/New Currency_Money")]
public class GuiTextType_Currency_Money : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_Currency_Money;
}
}
}

