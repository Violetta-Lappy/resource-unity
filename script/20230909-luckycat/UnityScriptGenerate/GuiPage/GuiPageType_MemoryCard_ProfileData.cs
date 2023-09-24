using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MemoryCard_ProfileData", menuName = "VLGameProject/GuiPage/New MemoryCard_ProfileData")]
public class GuiPageType_MemoryCard_ProfileData : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MemoryCard_ProfileData;
}
}
}

