using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Pause_Minimal", menuName = "VLGameProject/GuiPage/New Pause_Minimal")]
public class GuiPageType_Pause_Minimal : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Pause_Minimal;
}
}
}

