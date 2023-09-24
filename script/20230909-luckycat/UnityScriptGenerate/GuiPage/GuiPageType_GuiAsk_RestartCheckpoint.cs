using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GuiAsk_RestartCheckpoint", menuName = "VLGameProject/GuiPage/New GuiAsk_RestartCheckpoint")]
public class GuiPageType_GuiAsk_RestartCheckpoint : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GuiAsk_RestartCheckpoint;
}
}
}

