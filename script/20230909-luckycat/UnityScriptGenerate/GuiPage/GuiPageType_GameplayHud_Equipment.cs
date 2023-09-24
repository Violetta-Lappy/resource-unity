using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_Equipment", menuName = "VLGameProject/GuiPage/New GameplayHud_Equipment")]
public class GuiPageType_GameplayHud_Equipment : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_Equipment;
}
}
}

