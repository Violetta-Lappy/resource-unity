using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_TouchScreen", menuName = "VLGameProject/GuiPage/New Option_TouchScreen")]
public class GuiPageType_Option_TouchScreen : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_TouchScreen;
}
}
}

