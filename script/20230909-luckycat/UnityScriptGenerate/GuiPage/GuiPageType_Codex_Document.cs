using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex_Document", menuName = "VLGameProject/GuiPage/New Codex_Document")]
public class GuiPageType_Codex_Document : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex_Document;
}
}
}

