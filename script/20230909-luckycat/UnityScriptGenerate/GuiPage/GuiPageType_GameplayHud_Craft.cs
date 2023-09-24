using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_Craft", menuName = "VLGameProject/GuiPage/New GameplayHud_Craft")]
public class GuiPageType_GameplayHud_Craft : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_Craft;
}
}
}

