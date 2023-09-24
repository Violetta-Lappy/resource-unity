using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New MemoryCardGameDataQuickSave", menuName = "VLGameProject/InputAction/New MemoryCardGameDataQuickSave")]
    public class InputAction_MemoryCardGameDataQuickSave : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKSAVE, new KeyCode[] { KeyCode.F5 }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return new InputContextCombo[] {
                new InputContextCombo(ENUM_INPUT_CONTEXT.K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKSAVE, new KeyCode[] { KeyCode.LeftControl, KeyCode.S }),
                new InputContextCombo(ENUM_INPUT_CONTEXT.K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKSAVE, new KeyCode[] { KeyCode.RightControl, KeyCode.S }),
            };
        }
    }
}
