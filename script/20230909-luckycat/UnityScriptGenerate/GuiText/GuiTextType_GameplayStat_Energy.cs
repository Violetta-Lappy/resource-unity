using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayStat_Energy", menuName = "VLGameProject/GuiTextType/New GameplayStat_Energy")]
public class GuiTextType_GameplayStat_Energy : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayStat_Energy;
}
}
}

