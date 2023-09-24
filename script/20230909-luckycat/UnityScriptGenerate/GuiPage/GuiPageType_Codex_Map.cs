using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex_Map", menuName = "VLGameProject/GuiPage/New Codex_Map")]
public class GuiPageType_Codex_Map : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex_Map;
}
}
}

