using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New RewardSystem", menuName = "VLGameProject/GuiPage/New RewardSystem")]
public class GuiPageType_RewardSystem : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_RewardSystem;
}
}
}

