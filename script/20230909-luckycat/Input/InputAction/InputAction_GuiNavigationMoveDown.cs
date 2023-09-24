using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiNavigationMoveDown", menuName = "VLGameProject/InputAction/New GuiNavigationMoveDown")]
    public class InputAction_GuiNavigationMoveDown : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVEDOWN, new KeyCode[] { KeyCode.S, KeyCode.DownArrow }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
