using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New SP_GameSetup", menuName = "VLGameProject/GuiPage/New SP_GameSetup")]
public class GuiPageType_SP_GameSetup : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_SP_GameSetup;
}
}
}

