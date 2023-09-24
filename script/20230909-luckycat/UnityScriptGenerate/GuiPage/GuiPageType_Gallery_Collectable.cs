using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New Gallery_Collectable", menuName = "VLGameProject/GuiPage/New Gallery_Collectable")]
public class GuiPageType_Gallery_Collectable : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_Gallery_Collectable;
}
}
}

