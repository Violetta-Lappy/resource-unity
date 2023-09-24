using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New COOP_LevelSelect", menuName = "VLGameProject/GuiPage/New COOP_LevelSelect")]
public class GuiPageType_COOP_LevelSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_COOP_LevelSelect;
}
}
}

