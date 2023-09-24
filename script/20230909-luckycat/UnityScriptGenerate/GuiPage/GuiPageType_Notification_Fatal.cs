using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Notification_Fatal", menuName = "VLGameProject/GuiPage/New Notification_Fatal")]
public class GuiPageType_Notification_Fatal : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Notification_Fatal;
}
}
}

