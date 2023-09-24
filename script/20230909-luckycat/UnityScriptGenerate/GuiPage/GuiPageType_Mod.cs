using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Mod", menuName = "VLGameProject/GuiPage/New Mod")]
public class GuiPageType_Mod : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Mod;
}
}
}

