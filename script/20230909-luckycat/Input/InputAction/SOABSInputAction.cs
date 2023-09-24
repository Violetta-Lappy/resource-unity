using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLInput {
    public abstract class SOABSInputAction : ScriptableObject {
        public abstract InputContext[] Get_InputContext();
        public abstract InputContextCombo[] Get_InputContextCombo();
    }

    [CreateAssetMenu(fileName = "New Example", menuName = "VLGameProject/InputAction/New Example")]
    public class InputAction_Example : SOABSInputAction {
        public override InputContext[] Get_InputContext() {
            return new InputContext[] {
                new InputContext(ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVEUP, new KeyCode[] { KeyCode.W, KeyCode.UpArrow }),
            };
        }
        public override InputContextCombo[] Get_InputContextCombo() {
            return new InputContextCombo[] {
                new InputContextCombo(ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVEUP, new KeyCode[] { KeyCode.W, KeyCode.UpArrow }),
            };
        }
    }
}
