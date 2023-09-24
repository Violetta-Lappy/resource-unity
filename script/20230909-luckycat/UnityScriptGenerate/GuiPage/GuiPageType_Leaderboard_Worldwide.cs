using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard_Worldwide", menuName = "VLGameProject/GuiPage/New Leaderboard_Worldwide")]
public class GuiPageType_Leaderboard_Worldwide : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard_Worldwide;
}
}
}

