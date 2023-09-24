using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MP_GameSetup", menuName = "VLGameProject/GuiPage/New MP_GameSetup")]
public class GuiPageType_MP_GameSetup : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MP_GameSetup;
}
}
}

