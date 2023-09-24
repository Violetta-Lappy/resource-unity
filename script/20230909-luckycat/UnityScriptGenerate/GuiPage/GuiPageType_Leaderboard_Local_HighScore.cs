using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Local_HighScore", menuName = "VLGameProject/GuiPage/New Leaderboard_Local_HighScore")]
public class GuiPageType_Leaderboard_Local_HighScore : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Local_HighScore;
}
}
}

