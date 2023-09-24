using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Option_Keyboard", menuName = "VLGameProject/GuiPage/New Option_Keyboard")]
public class GuiPageType_Option_Keyboard : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Option_Keyboard;
}
}
}

