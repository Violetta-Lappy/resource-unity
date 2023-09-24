using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Notification_Error", menuName = "VLGameProject/GuiPage/New Notification_Error")]
public class GuiPageType_Notification_Error : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Notification_Error;
}
}
}

