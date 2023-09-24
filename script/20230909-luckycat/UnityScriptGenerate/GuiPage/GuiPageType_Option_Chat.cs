using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_Chat", menuName = "VLGameProject/GuiPage/New Option_Chat")]
public class GuiPageType_Option_Chat : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_Chat;
}
}
}

