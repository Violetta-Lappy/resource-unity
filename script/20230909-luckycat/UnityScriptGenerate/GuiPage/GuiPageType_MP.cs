using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MP", menuName = "VLGameProject/GuiPage/New MP")]
public class GuiPageType_MP : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MP;
}
}
}

