using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MP_ServerFind", menuName = "VLGameProject/GuiPage/New MP_ServerFind")]
public class GuiPageType_MP_ServerFind : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MP_ServerFind;
}
}
}

