using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New DateTime_Date", menuName = "VLGameProject/GuiTextType/New DateTime_Date")]
public class GuiTextType_DateTime_Date : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_DateTime_Date;
}
}
}

