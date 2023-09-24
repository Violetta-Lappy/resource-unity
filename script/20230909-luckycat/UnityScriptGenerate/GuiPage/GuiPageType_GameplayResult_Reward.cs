using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayResult_Reward", menuName = "VLGameProject/GuiPage/New GameplayResult_Reward")]
public class GuiPageType_GameplayResult_Reward : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GameplayResult_Reward;
}
}
}

