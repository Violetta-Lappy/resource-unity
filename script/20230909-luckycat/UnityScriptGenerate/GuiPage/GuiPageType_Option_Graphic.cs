using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_Graphic", menuName = "VLGameProject/GuiPage/New Option_Graphic")]
public class GuiPageType_Option_Graphic : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_Graphic;
}
}
}

