using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayStat_Stamina", menuName = "VLGameProject/GuiTextType/New GameplayStat_Stamina")]
public class GuiTextType_GameplayStat_Stamina : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayStat_Stamina;
}
}
}

