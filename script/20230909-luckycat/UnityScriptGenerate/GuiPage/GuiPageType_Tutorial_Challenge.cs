using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Tutorial_Challenge", menuName = "VLGameProject/GuiPage/New Tutorial_Challenge")]
public class GuiPageType_Tutorial_Challenge : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Tutorial_Challenge;
}
}
}

