using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Inbox", menuName = "VLGameProject/GuiPage/New Inbox")]
public class GuiPageType_Inbox : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Inbox;
}
}
}

