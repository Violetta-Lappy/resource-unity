using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiNavigationConfirm", menuName = "VLGameProject/InputAction/New GuiNavigationConfirm")]
    public class InputAction_GuiNavigationConfirm : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_CONFIRM, new KeyCode[] { KeyCode.Return, KeyCode.KeypadEnter }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
