using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GuiAsk_ExitToDesktop", menuName = "VLGameProject/GuiPage/New GuiAsk_ExitToDesktop")]
public class GuiPageType_GuiAsk_ExitToDesktop : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GuiAsk_ExitToDesktop;
}
}
}

