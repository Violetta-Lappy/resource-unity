using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New TitleScreen", menuName = "VLGameProject/GuiPage/New TitleScreen")]
public class GuiPageType_TitleScreen : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_TitleScreen;
}
}
}

