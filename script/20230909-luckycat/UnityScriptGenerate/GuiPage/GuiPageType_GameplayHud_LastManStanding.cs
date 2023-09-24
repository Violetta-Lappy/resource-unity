using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_LastManStanding", menuName = "VLGameProject/GuiPage/New GameplayHud_LastManStanding")]
public class GuiPageType_GameplayHud_LastManStanding : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_LastManStanding;
}
}
}

