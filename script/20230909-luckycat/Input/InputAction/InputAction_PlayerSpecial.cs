using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New PlayerSpecial", menuName = "VLGameProject/InputAction/New PlayerSpecial")]
    public class InputAction_PlayerSpecial : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_PLAYER_SPECIAL, new KeyCode[] { KeyCode.W, KeyCode.UpArrow }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
