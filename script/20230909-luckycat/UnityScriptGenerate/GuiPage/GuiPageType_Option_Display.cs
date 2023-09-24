using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_Display", menuName = "VLGameProject/GuiPage/New Option_Display")]
public class GuiPageType_Option_Display : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_Display;
}
}
}

