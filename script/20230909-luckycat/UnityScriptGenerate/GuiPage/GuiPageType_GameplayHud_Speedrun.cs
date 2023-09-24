using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_Speedrun", menuName = "VLGameProject/GuiPage/New GameplayHud_Speedrun")]
public class GuiPageType_GameplayHud_Speedrun : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_Speedrun;
}
}
}

