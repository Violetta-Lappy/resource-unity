using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MP_MissionSelect", menuName = "VLGameProject/GuiPage/New MP_MissionSelect")]
public class GuiPageType_MP_MissionSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MP_MissionSelect;
}
}
}

