using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GuiInventory", menuName = "VLGameProject/InputAction/New GuiInventory")]
    public class InputAction_GuiInventory : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_GUI_INVENTORY, new KeyCode[] { KeyCode.I }),
            };
        }
        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
