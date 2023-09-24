using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New PlayerMoveLeft", menuName = "VLGameProject/InputAction/New PlayerMoveLeft")]
    public class InputAction_PlayerMoveLeft : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVELEFT, new KeyCode[] { KeyCode.A, KeyCode.LeftArrow }),
            };
        }
        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
