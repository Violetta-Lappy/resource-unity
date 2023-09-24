using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New PlayerMoveUp", menuName = "VLGameProject/InputAction/New PlayerMoveUp")]
    public class InputAction_PlayerMoveUp : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVEUP, new KeyCode[] { KeyCode.W, KeyCode.UpArrow }),
            };
        }
        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
