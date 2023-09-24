using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayResult", menuName = "VLGameProject/GuiPage/New GameplayResult")]
public class GuiPageType_GameplayResult : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayResult;
}
}
}

