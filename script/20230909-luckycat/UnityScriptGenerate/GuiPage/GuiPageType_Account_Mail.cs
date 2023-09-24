using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Account_Mail", menuName = "VLGameProject/GuiPage/New Account_Mail")]
public class GuiPageType_Account_Mail : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Account_Mail;
}
}
}

