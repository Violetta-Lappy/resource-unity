using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Credit", menuName = "VLGameProject/GuiPage/New Credit")]
public class GuiPageType_Credit : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Credit;
}
}
}

