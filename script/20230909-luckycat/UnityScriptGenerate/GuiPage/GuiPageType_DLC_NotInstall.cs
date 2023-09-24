using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New DLC_NotInstall", menuName = "VLGameProject/GuiPage/New DLC_NotInstall")]
public class GuiPageType_DLC_NotInstall : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_DLC_NotInstall;
}
}
}

