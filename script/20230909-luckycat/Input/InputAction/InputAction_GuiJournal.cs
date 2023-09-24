using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiJournal", menuName = "VLGameProject/InputAction/New GuiJournal")]
    public class InputAction_GuiJournal : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_GUI_JOURNAL, new KeyCode[] { KeyCode.J }),
            };
        }
        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
