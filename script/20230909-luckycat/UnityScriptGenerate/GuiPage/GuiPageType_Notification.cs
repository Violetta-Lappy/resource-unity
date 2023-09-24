using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Notification", menuName = "VLGameProject/GuiPage/New Notification")]
public class GuiPageType_Notification : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Notification;
}
}
}

