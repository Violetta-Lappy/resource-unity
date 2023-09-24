using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Tutorial", menuName = "VLGameProject/GuiPage/New Tutorial")]
public class GuiPageType_Tutorial : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Tutorial;
}
}
}

