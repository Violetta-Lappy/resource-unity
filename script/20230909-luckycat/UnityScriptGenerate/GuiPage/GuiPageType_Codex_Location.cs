using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Codex_Location", menuName = "VLGameProject/GuiPage/New Codex_Location")]
public class GuiPageType_Codex_Location : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Codex_Location;
}
}
}

