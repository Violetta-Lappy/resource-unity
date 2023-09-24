using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayValue_Mana", menuName = "VLGameProject/GuiTextType/New GameplayValue_Mana")]
public class GuiTextType_GameplayValue_Mana : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayValue_Mana;
}
}
}

