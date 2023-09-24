using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New IAP", menuName = "VLGameProject/GuiPage/New IAP")]
public class GuiPageType_IAP : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_IAP;
}
}
}

