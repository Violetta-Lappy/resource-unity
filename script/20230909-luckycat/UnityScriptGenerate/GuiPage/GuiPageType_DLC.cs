using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New DLC", menuName = "VLGameProject/GuiPage/New DLC")]
public class GuiPageType_DLC : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_DLC;
}
}
}

