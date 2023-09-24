using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_Inventory", menuName = "VLGameProject/GuiPage/New GameplayHud_Inventory")]
public class GuiPageType_GameplayHud_Inventory : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_Inventory;
}
}
}

