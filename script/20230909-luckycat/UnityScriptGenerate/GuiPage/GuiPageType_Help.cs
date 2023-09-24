using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Help", menuName = "VLGameProject/GuiPage/New Help")]
public class GuiPageType_Help : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Help;
}
}
}

