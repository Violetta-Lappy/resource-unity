using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Pause", menuName = "VLGameProject/GuiPage/New Pause")]
public class GuiPageType_Pause : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Pause;
}
}
}

