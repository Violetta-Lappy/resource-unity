using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Gallery_Video", menuName = "VLGameProject/GuiPage/New Gallery_Video")]
public class GuiPageType_Gallery_Video : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Gallery_Video;
}
}
}

