using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiNavigationMoveLeft", menuName = "VLGameProject/InputAction/New GuiNavigationMoveLeft")]
    public class InputAction_GuiNavigationMoveLeft : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVELEFT, new KeyCode[] { KeyCode.A, KeyCode.LeftArrow }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
