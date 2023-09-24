using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New MP_ChapterSelect", menuName = "VLGameProject/GuiPage/New MP_ChapterSelect")]
public class GuiPageType_MP_ChapterSelect : SOABSGuiPageType {
public override ENUMGuiPage Get_GuiPageType() {
return ENUMGuiPage.K_MP_ChapterSelect;
}
}
}

