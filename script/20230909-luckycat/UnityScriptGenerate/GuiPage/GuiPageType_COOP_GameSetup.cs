using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New COOP_GameSetup", menuName = "VLGameProject/GuiPage/New COOP_GameSetup")]
public class GuiPageType_COOP_GameSetup : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_COOP_GameSetup;
}
}
}

