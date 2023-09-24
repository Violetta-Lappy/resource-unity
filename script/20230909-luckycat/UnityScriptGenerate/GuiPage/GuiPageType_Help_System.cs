using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Help_System", menuName = "VLGameProject/GuiPage/New Help_System")]
public class GuiPageType_Help_System : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Help_System;
}
}
}

