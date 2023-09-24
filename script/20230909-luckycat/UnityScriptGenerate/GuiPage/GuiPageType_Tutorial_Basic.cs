using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Tutorial_Basic", menuName = "VLGameProject/GuiPage/New Tutorial_Basic")]
public class GuiPageType_Tutorial_Basic : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Tutorial_Basic;
}
}
}

