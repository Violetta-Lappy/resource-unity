using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New SplashScreen", menuName = "VLGameProject/GuiPage/New SplashScreen")]
public class GuiPageType_SplashScreen : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_SplashScreen;
}
}
}

