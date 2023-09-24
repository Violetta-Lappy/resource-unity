using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex_Enemy", menuName = "VLGameProject/GuiPage/New Codex_Enemy")]
public class GuiPageType_Codex_Enemy : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex_Enemy;
}
}
}

