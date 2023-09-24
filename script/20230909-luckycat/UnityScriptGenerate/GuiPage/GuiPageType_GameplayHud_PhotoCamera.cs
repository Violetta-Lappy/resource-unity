using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_PhotoCamera", menuName = "VLGameProject/GuiPage/New GameplayHud_PhotoCamera")]
public class GuiPageType_GameplayHud_PhotoCamera : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_PhotoCamera;
}
}
}

