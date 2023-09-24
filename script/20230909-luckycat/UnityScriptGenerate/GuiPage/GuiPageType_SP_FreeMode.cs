using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New SP_FreeMode", menuName = "VLGameProject/GuiPage/New SP_FreeMode")]
public class GuiPageType_SP_FreeMode : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_SP_FreeMode;
}
}
}

