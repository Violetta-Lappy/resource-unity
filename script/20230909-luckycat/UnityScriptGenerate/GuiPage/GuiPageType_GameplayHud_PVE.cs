using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_PVE", menuName = "VLGameProject/GuiPage/New GameplayHud_PVE")]
public class GuiPageType_GameplayHud_PVE : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_PVE;
}
}
}

