using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New PlayerMoveDown", menuName = "VLGameProject/InputAction/New PlayerMoveDown")]
    public class InputAction_PlayerMoveDown : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVEDOWN, new KeyCode[] { KeyCode.S, KeyCode.DownArrow }),
            };
        }        
        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
