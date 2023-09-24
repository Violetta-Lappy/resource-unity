using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New LoadingScreen", menuName = "VLGameProject/GuiPage/New LoadingScreen")]
public class GuiPageType_LoadingScreen : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_LoadingScreen;
}
}
}

