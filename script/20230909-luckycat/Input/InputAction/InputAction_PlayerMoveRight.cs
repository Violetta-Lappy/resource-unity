using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New PlayerMoveRight", menuName = "VLGameProject/InputAction/New PlayerMoveRight")]
    public class InputAction_PlayerMoveRight : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVERIGHT, new KeyCode[] { KeyCode.D, KeyCode.RightArrow }),
            };
        }
        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
