using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Personal_TimeAttack", menuName = "VLGameProject/GuiPage/New Leaderboard_Personal_TimeAttack")]
public class GuiPageType_Leaderboard_Personal_TimeAttack : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Personal_TimeAttack;
}
}
}

