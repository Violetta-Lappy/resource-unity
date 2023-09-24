using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_Mouse", menuName = "VLGameProject/GuiPage/New Option_Mouse")]
public class GuiPageType_Option_Mouse : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_Mouse;
}
}
}

