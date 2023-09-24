using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New SP_LevelSelect", menuName = "VLGameProject/GuiPage/New SP_LevelSelect")]
public class GuiPageType_SP_LevelSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_SP_LevelSelect;
}
}
}

