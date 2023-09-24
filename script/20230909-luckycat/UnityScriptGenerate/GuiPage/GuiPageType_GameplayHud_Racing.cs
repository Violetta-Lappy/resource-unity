using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_Racing", menuName = "VLGameProject/GuiPage/New GameplayHud_Racing")]
public class GuiPageType_GameplayHud_Racing : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_Racing;
}
}
}

