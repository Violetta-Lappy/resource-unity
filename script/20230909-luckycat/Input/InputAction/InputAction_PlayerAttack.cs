using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New PlayerAttack", menuName = "VLGameProject/InputAction/New PlayerAttack")]
    public class InputAction_PlayerAttack : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_GAME_PLAYER_ATTACK, new KeyCode[] { KeyCode.Mouse0, KeyCode.Z }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return null;
        }
    }
}
