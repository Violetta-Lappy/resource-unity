using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex_People", menuName = "VLGameProject/GuiPage/New Codex_People")]
public class GuiPageType_Codex_People : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex_People;
}
}
}

