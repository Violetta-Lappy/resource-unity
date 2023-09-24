using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GuiAsk_ExitToMainMenu", menuName = "VLGameProject/GuiPage/New GuiAsk_ExitToMainMenu")]
public class GuiPageType_GuiAsk_ExitToMainMenu : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GuiAsk_ExitToMainMenu;
}
}
}

