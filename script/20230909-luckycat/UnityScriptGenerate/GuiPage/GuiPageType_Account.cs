using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Account", menuName = "VLGameProject/GuiPage/New Account")]
public class GuiPageType_Account : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Account;
}
}
}

