using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Account_Achievement", menuName = "VLGameProject/GuiPage/New Account_Achievement")]
public class GuiPageType_Account_Achievement : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Account_Achievement;
}
}
}

