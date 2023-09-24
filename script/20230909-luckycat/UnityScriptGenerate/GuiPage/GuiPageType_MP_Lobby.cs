using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MP_Lobby", menuName = "VLGameProject/GuiPage/New MP_Lobby")]
public class GuiPageType_MP_Lobby : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MP_Lobby;
}
}
}

