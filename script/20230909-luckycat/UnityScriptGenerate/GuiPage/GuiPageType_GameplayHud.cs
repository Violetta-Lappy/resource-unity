using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud", menuName = "VLGameProject/GuiPage/New GameplayHud")]
public class GuiPageType_GameplayHud : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud;
}
}
}

