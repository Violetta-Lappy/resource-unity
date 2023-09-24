using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_Bowling", menuName = "VLGameProject/GuiPage/New GameplayHud_Bowling")]
public class GuiPageType_GameplayHud_Bowling : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_Bowling;
}
}
}

