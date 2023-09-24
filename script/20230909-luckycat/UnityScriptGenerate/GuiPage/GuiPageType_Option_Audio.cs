using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_Audio", menuName = "VLGameProject/GuiPage/New Option_Audio")]
public class GuiPageType_Option_Audio : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_Audio;
}
}
}

