using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New SP", menuName = "VLGameProject/GuiPage/New SP")]
public class GuiPageType_SP : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_SP;
}
}
}

