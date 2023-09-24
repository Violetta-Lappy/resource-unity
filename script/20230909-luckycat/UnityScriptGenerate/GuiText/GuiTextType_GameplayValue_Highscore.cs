using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayValue_Highscore", menuName = "VLGameProject/GuiTextType/New GameplayValue_Highscore")]
public class GuiTextType_GameplayValue_Highscore : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayValue_Highscore;
}
}
}

