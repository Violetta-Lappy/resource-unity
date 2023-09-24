using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayStat_Mana", menuName = "VLGameProject/GuiTextType/New GameplayStat_Mana")]
public class GuiTextType_GameplayStat_Mana : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayStat_Mana;
}
}
}

