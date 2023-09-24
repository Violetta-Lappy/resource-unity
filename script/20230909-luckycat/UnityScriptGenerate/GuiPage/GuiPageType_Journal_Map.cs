using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Journal_Map", menuName = "VLGameProject/GuiPage/New Journal_Map")]
public class GuiPageType_Journal_Map : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Journal_Map;
}
}
}

