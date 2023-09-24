using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayValue_Health", menuName = "VLGameProject/GuiTextType/New GameplayValue_Health")]
public class GuiTextType_GameplayValue_Health : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayValue_Health;
}
}
}

