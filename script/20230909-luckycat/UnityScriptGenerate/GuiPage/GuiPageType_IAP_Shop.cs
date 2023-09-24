using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New IAP_Shop", menuName = "VLGameProject/GuiPage/New IAP_Shop")]
public class GuiPageType_IAP_Shop : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_IAP_Shop;
}
}
}

