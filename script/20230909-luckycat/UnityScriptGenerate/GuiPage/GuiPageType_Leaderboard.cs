using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Leaderboard", menuName = "VLGameProject/GuiPage/New Leaderboard")]
public class GuiPageType_Leaderboard : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Leaderboard;
}
}
}

