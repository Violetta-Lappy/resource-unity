using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Tutorial_Intermediate", menuName = "VLGameProject/GuiPage/New Tutorial_Intermediate")]
public class GuiPageType_Tutorial_Intermediate : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Tutorial_Intermediate;
}
}
}

