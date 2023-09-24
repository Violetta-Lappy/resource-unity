using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex", menuName = "VLGameProject/GuiPage/New Codex")]
public class GuiPageType_Codex : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex;
}
}
}

