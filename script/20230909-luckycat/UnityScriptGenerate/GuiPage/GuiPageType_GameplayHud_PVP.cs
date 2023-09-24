using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_PVP", menuName = "VLGameProject/GuiPage/New GameplayHud_PVP")]
public class GuiPageType_GameplayHud_PVP : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_PVP;
}
}
}

