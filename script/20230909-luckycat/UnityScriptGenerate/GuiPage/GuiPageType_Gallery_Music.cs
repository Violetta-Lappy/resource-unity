using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Gallery_Music", menuName = "VLGameProject/GuiPage/New Gallery_Music")]
public class GuiPageType_Gallery_Music : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Gallery_Music;
}
}
}

