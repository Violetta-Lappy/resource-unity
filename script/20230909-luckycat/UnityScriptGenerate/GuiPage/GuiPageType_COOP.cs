using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New COOP", menuName = "VLGameProject/GuiPage/New COOP")]
public class GuiPageType_COOP : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_COOP;
}
}
}

