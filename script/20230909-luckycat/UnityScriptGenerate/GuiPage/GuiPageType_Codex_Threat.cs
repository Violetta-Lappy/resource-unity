using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex_Threat", menuName = "VLGameProject/GuiPage/New Codex_Threat")]
public class GuiPageType_Codex_Threat : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex_Threat;
}
}
}

