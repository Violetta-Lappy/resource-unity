using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiNavigationMoveRight", menuName = "VLGameProject/InputAction/New GuiNavigationMoveRight")]
    public class InputAction_GuiNavigationMoveRight : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVERIGHT, new KeyCode[] { KeyCode.D, KeyCode.RightArrow }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
