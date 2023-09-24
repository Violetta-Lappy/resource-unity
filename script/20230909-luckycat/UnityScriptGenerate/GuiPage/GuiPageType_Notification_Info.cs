using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Notification_Info", menuName = "VLGameProject/GuiPage/New Notification_Info")]
public class GuiPageType_Notification_Info : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Notification_Info;
}
}
}

