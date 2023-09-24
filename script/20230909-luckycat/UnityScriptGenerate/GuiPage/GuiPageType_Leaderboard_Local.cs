using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Local", menuName = "VLGameProject/GuiPage/New Leaderboard_Local")]
public class GuiPageType_Leaderboard_Local : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Local;
}
}
}

