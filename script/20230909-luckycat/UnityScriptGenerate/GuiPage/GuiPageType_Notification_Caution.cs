using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Notification_Caution", menuName = "VLGameProject/GuiPage/New Notification_Caution")]
public class GuiPageType_Notification_Caution : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Notification_Caution;
}
}
}

