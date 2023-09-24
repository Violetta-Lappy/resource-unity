using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex_Player", menuName = "VLGameProject/GuiPage/New Codex_Player")]
public class GuiPageType_Codex_Player : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex_Player;
}
}
}

