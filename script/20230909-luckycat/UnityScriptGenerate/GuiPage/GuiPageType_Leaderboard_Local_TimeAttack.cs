using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Local_TimeAttack", menuName = "VLGameProject/GuiPage/New Leaderboard_Local_TimeAttack")]
public class GuiPageType_Leaderboard_Local_TimeAttack : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Local_TimeAttack;
}
}
}

