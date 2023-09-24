using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Mailbox", menuName = "VLGameProject/GuiPage/New Mailbox")]
public class GuiPageType_Mailbox : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Mailbox;
}
}
}

