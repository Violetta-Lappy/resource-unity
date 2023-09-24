using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MainMenu", menuName = "VLGameProject/GuiPage/New MainMenu")]
public class GuiPageType_MainMenu : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MainMenu;
}
}
}

