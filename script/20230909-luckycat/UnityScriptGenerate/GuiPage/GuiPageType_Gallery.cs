using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Gallery", menuName = "VLGameProject/GuiPage/New Gallery")]
public class GuiPageType_Gallery : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Gallery;
}
}
}

