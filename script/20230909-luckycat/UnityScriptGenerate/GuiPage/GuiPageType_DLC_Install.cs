using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New DLC_Install", menuName = "VLGameProject/GuiPage/New DLC_Install")]
public class GuiPageType_DLC_Install : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_DLC_Install;
}
}
}

