using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_HighScore", menuName = "VLGameProject/GuiPage/New GameplayHud_HighScore")]
public class GuiPageType_GameplayHud_HighScore : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_HighScore;
}
}
}

