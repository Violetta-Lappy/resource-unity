using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New DateTime_Time", menuName = "VLGameProject/GuiTextType/New DateTime_Time")]
public class GuiTextType_DateTime_Time : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_DateTime_Time;
}
}
}

