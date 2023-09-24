using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New SP_MissionSelect", menuName = "VLGameProject/GuiPage/New SP_MissionSelect")]
public class GuiPageType_SP_MissionSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_SP_MissionSelect;
}
}
}

