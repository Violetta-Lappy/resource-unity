using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_CaptureTheFlag", menuName = "VLGameProject/GuiPage/New GameplayHud_CaptureTheFlag")]
public class GuiPageType_GameplayHud_CaptureTheFlag : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_CaptureTheFlag;
}
}
}

