using UnityEngine;
namespace VLGameProject.VLGui {
[CreateAssetMenu(fileName = "New GameplayValue_EnemyCount", menuName = "VLGameProject/GuiTextType/New GameplayValue_EnemyCount")]
public class GuiTextType_GameplayValue_EnemyCount : SOABSGuiTextType {
public override ENUMGuiText Get_GuiTextType() {
return ENUMGuiText.K_GameplayValue_EnemyCount;
}
}
}

