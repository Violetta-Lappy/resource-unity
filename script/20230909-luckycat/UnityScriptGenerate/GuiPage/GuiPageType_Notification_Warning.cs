using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Notification_Warning", menuName = "VLGameProject/GuiPage/New Notification_Warning")]
public class GuiPageType_Notification_Warning : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Notification_Warning;
}
}
}

