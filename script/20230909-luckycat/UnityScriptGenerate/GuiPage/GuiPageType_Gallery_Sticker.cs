using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Gallery_Sticker", menuName = "VLGameProject/GuiPage/New Gallery_Sticker")]
public class GuiPageType_Gallery_Sticker : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Gallery_Sticker;
}
}
}

