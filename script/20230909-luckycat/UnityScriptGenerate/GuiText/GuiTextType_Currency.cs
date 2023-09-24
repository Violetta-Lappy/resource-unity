using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Currency", menuName = "VLGameProject/GuiTextType/New Currency")]
public class GuiTextType_Currency : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_Currency;
}
}
}

