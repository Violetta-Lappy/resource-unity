using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayValue_Energy", menuName = "VLGameProject/GuiTextType/New GameplayValue_Energy")]
public class GuiTextType_GameplayValue_Energy : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayValue_Energy;
}
}
}

