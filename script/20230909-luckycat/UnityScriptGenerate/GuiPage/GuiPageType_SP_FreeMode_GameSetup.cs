using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New SP_FreeMode_GameSetup", menuName = "VLGameProject/GuiPage/New SP_FreeMode_GameSetup")]
public class GuiPageType_SP_FreeMode_GameSetup : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_SP_FreeMode_GameSetup;
}
}
}

