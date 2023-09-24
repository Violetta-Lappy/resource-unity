using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Currency_Coin", menuName = "VLGameProject/GuiTextType/New Currency_Coin")]
public class GuiTextType_Currency_Coin : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_Currency_Coin;
}
}
}

