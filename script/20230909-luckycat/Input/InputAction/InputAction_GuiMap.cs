using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiMap", menuName = "VLGameProject/InputAction/New GuiMap")]
    public class InputAction_GuiMap : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_GUI_MAP, new KeyCode[] { KeyCode.M }),
            };
        }
        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
