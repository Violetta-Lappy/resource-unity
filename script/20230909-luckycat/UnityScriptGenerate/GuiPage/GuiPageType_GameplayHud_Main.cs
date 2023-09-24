using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_Main", menuName = "VLGameProject/GuiPage/New GameplayHud_Main")]
public class GuiPageType_GameplayHud_Main : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_Main;
}
}
}

