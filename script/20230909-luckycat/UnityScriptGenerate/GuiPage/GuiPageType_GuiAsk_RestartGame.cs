using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GuiAsk_RestartGame", menuName = "VLGameProject/GuiPage/New GuiAsk_RestartGame")]
public class GuiPageType_GuiAsk_RestartGame : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_GuiAsk_RestartGame;
}
}
}

