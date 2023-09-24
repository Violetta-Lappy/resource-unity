using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayValue_TimeLimit", menuName = "VLGameProject/GuiTextType/New GameplayValue_TimeLimit")]
public class GuiTextType_GameplayValue_TimeLimit : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayValue_TimeLimit;
}
}
}

