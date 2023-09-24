using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Help_Game", menuName = "VLGameProject/GuiPage/New Help_Game")]
public class GuiPageType_Help_Game : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Help_Game;
}
}
}

