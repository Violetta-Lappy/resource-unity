using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Mail", menuName = "VLGameProject/GuiPage/New Mail")]
public class GuiPageType_Mail : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Mail;
}
}
}

