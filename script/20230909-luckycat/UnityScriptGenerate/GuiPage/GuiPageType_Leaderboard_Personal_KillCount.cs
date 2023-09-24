using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Personal_KillCount", menuName = "VLGameProject/GuiPage/New Leaderboard_Personal_KillCount")]
public class GuiPageType_Leaderboard_Personal_KillCount : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Personal_KillCount;
}
}
}

