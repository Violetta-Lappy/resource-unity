using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayStat_Health", menuName = "VLGameProject/GuiTextType/New GameplayStat_Health")]
public class GuiTextType_GameplayStat_Health : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayStat_Health;
}
}
}

