using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New IAP_Shop_Consumable", menuName = "VLGameProject/GuiPage/New IAP_Shop_Consumable")]
public class GuiPageType_IAP_Shop_Consumable : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_IAP_Shop_Consumable;
}
}
}

