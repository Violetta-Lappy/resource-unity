using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New MemoryCardGameDataQuickLoad", menuName = "VLGameProject/InputAction/New MemoryCardGameDataQuickLoad")]
    public class InputAction_MemoryCardGameDataQuickLoad : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKLOAD, new KeyCode[] { KeyCode.F9 }),
            };
        }

        public override InputContextCombo[] Get_InputContextCombo() {
            return new InputContextCombo[] {
                new InputContextCombo(ENUM_INPUT_CONTEXT.K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKLOAD, new KeyCode[] { KeyCode.LeftControl, KeyCode.L }),
                new InputContextCombo(ENUM_INPUT_CONTEXT.K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKLOAD, new KeyCode[] { KeyCode.RightControl, KeyCode.L }),
            };
        }
    }
}
