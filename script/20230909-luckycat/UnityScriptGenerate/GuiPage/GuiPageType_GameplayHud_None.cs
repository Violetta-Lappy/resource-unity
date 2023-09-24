using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_None", menuName = "VLGameProject/GuiPage/New GameplayHud_None")]
public class GuiPageType_GameplayHud_None : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_None;
}
}
}

