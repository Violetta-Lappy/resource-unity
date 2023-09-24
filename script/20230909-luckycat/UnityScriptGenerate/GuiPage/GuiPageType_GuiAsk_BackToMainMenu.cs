using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GuiAsk_BackToMainMenu", menuName = "VLGameProject/GuiPage/New GuiAsk_BackToMainMenu")]
public class GuiPageType_GuiAsk_BackToMainMenu : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GuiAsk_BackToMainMenu;
}
}
}

