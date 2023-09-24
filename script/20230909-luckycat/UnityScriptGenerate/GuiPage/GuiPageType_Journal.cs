using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Journal", menuName = "VLGameProject/GuiPage/New Journal")]
public class GuiPageType_Journal : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Journal;
}
}
}

