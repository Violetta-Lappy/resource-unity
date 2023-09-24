using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayValue_Stamina", menuName = "VLGameProject/GuiTextType/New GameplayValue_Stamina")]
public class GuiTextType_GameplayValue_Stamina : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayValue_Stamina;
}
}
}

