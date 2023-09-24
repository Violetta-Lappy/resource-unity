using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Gallery_Illustration", menuName = "VLGameProject/GuiPage/New Gallery_Illustration")]
public class GuiPageType_Gallery_Illustration : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Gallery_Illustration;
}
}
}

