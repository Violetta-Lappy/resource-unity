using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_Notification", menuName = "VLGameProject/GuiPage/New Option_Notification")]
public class GuiPageType_Option_Notification : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_Notification;
}
}
}

