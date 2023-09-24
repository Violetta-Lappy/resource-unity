using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Worldwide_HighScore", menuName = "VLGameProject/GuiPage/New Leaderboard_Worldwide_HighScore")]
public class GuiPageType_Leaderboard_Worldwide_HighScore : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Worldwide_HighScore;
}
}
}

