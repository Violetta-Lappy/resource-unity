using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option", menuName = "VLGameProject/GuiPage/New Option")]
public class GuiPageType_Option : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option;
}
}
}

