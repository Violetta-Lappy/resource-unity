using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New SP_ChapterSelect", menuName = "VLGameProject/GuiPage/New SP_ChapterSelect")]
public class GuiPageType_SP_ChapterSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_SP_ChapterSelect;
}
}
}

