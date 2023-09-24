using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MemoryCard_GameData", menuName = "VLGameProject/GuiPage/New MemoryCard_GameData")]
public class GuiPageType_MemoryCard_GameData : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MemoryCard_GameData;
}
}
}

