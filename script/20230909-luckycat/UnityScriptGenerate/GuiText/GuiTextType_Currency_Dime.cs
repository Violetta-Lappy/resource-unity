using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Currency_Dime", menuName = "VLGameProject/GuiTextType/New Currency_Dime")]
public class GuiTextType_Currency_Dime : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_Currency_Dime;
}
}
}

