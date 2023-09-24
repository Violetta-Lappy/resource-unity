using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLInput {
    public abstract class ABSInputComponent : GameProgramObject {
        [Header("GameInput")]
        //public GameInputPreset m_gameInputPreset; NOT-NEEDED, KINDA-OVERCOMPLICATE-EVERYTHING
        public int i32_inputId;
        public int Get_InputId() { return i32_inputId; }
        public void Set_InputId(int arg_id) => i32_inputId = arg_id;

        public override void Awake() {
            base.Awake();
            //GameInput_Init(Get_GameProgram().Get_InputManager());
        }

        private void OnEnable() {
            GameInput_Init(Get_GameProgram().Get_InputManager());
        }

        private void OnDisable() {
            GameInput_Clean(Get_GameProgram().Get_InputManager());
        }

        private void OnDestroy() {
            GameInput_Clean(Get_GameProgram().Get_InputManager());
        }

        public abstract void GameInput_Init(InputManager arg_inputManager);
        public abstract void GameInput_Clean(InputManager arg_inputManager);

        public abstract void InputContext_Press(ENUM_INPUT_CONTEXT arg_type);
        public abstract void InputContext_Hold(ENUM_INPUT_CONTEXT arg_type);
        public abstract void InputContext_Release(ENUM_INPUT_CONTEXT arg_type);

        //public abstract void TouchContext_Press(ENUM_INPUT_CONTEXT arg_type); //Began
        //public abstract void TouchContext_HoldStay(ENUM_INPUT_CONTEXT arg_type); //Stationary
        //public abstract void TouchContext_HoldMove(ENUM_INPUT_CONTEXT arg_type); //Move
        //public abstract void TouchContext_Release(ENUM_INPUT_CONTEXT arg_type); //Ended
        //public abstract void TouchContext_End(ENUM_INPUT_CONTEXT arg_type); //Canceled

        public ENUM_INPUT_CONTEXT arg_touchContextType;
        //public abstract void InputContext_TouchPress();
        //public abstract void InputContext_TouchHold();
        //public abstract void InputContext_TouchRelease();
    }
}

