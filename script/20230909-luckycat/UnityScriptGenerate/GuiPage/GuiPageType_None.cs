using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New None", menuName = "VLGameProject/GuiPage/New None")]
public class GuiPageType_None : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_None;
}
}
}

