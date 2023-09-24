using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiNavigationBack", menuName = "VLGameProject/InputAction/New GuiNavigationBack")]
    public class InputAction_GuiNavigationBack : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_BACK, new KeyCode[] { KeyCode.Escape, KeyCode.Backspace }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
