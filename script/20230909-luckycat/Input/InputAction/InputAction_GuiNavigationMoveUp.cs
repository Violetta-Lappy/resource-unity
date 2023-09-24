using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiNavigationMoveUp", menuName = "VLGameProject/InputAction/New GuiNavigationMoveUp")]
    public class InputAction_GuiNavigationMoveUp : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVEUP, new KeyCode[] { KeyCode.W, KeyCode.UpArrow }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
