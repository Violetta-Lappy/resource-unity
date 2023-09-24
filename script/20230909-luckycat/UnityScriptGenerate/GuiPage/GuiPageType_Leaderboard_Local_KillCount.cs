using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Local_KillCount", menuName = "VLGameProject/GuiPage/New Leaderboard_Local_KillCount")]
public class GuiPageType_Leaderboard_Local_KillCount : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Local_KillCount;
}
}
}

