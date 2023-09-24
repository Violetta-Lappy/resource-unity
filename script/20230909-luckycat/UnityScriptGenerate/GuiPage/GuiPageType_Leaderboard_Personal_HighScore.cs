using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Personal_HighScore", menuName = "VLGameProject/GuiPage/New Leaderboard_Personal_HighScore")]
public class GuiPageType_Leaderboard_Personal_HighScore : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Personal_HighScore;
}
}
}

