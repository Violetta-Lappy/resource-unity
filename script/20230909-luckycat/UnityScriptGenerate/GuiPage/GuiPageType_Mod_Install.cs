using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Mod_Install", menuName = "VLGameProject/GuiPage/New Mod_Install")]
public class GuiPageType_Mod_Install : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Mod_Install;
}
}
}

