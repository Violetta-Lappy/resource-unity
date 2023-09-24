using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Personal", menuName = "VLGameProject/GuiPage/New Leaderboard_Personal")]
public class GuiPageType_Leaderboard_Personal : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Personal;
}
}
}

