using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_Gamepad", menuName = "VLGameProject/GuiPage/New Option_Gamepad")]
public class GuiPageType_Option_Gamepad : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_Gamepad;
}
}
}

