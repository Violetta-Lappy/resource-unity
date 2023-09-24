using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Mod_NotInstall", menuName = "VLGameProject/GuiPage/New Mod_NotInstall")]
public class GuiPageType_Mod_NotInstall : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Mod_NotInstall;
}
}
}

