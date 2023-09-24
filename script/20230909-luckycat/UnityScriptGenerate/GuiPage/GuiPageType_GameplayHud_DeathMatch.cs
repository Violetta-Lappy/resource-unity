using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_DeathMatch", menuName = "VLGameProject/GuiPage/New GameplayHud_DeathMatch")]
public class GuiPageType_GameplayHud_DeathMatch : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_DeathMatch;
}
}
}

