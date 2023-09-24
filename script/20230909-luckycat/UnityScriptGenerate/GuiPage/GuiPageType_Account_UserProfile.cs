using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Account_UserProfile", menuName = "VLGameProject/GuiPage/New Account_UserProfile")]
public class GuiPageType_Account_UserProfile : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Account_UserProfile;
}
}
}

