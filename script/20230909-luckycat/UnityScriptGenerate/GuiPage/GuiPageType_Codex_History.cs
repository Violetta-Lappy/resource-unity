using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex_History", menuName = "VLGameProject/GuiPage/New Codex_History")]
public class GuiPageType_Codex_History : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex_History;
}
}
}

