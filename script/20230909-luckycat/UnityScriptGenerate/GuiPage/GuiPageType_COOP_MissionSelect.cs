using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New COOP_MissionSelect", menuName = "VLGameProject/GuiPage/New COOP_MissionSelect")]
public class GuiPageType_COOP_MissionSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_COOP_MissionSelect;
}
}
}

