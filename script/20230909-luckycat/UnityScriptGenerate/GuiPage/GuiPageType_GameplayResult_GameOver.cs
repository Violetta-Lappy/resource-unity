using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayResult_GameOver", menuName = "VLGameProject/GuiPage/New GameplayResult_GameOver")]
public class GuiPageType_GameplayResult_GameOver : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayResult_GameOver;
}
}
}

