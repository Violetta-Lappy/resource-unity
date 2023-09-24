using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New COOP_ChapterSelect", menuName = "VLGameProject/GuiPage/New COOP_ChapterSelect")]
public class GuiPageType_COOP_ChapterSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_COOP_ChapterSelect;
}
}
}

