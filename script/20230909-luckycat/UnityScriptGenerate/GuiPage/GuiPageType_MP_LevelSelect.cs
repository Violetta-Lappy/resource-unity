using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MP_LevelSelect", menuName = "VLGameProject/GuiPage/New MP_LevelSelect")]
public class GuiPageType_MP_LevelSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MP_LevelSelect;
}
}
}

