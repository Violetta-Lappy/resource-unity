using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Tutorial_Advance", menuName = "VLGameProject/GuiPage/New Tutorial_Advance")]
public class GuiPageType_Tutorial_Advance : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Tutorial_Advance;
}
}
}

