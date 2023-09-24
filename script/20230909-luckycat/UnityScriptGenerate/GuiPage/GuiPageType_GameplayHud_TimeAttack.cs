using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayHud_TimeAttack", menuName = "VLGameProject/GuiPage/New GameplayHud_TimeAttack")]
public class GuiPageType_GameplayHud_TimeAttack : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayHud_TimeAttack;
}
}
}

