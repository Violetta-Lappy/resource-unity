using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Worldwide_KillCount", menuName = "VLGameProject/GuiPage/New Leaderboard_Worldwide_KillCount")]
public class GuiPageType_Leaderboard_Worldwide_KillCount : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Worldwide_KillCount;
}
}
}

