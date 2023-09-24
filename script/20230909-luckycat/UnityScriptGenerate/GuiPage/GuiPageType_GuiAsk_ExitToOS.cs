using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GuiAsk_ExitToOS", menuName = "VLGameProject/GuiPage/New GuiAsk_ExitToOS")]
public class GuiPageType_GuiAsk_ExitToOS : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GuiAsk_ExitToOS;
}
}
}

