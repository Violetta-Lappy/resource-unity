using System;
using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

namespace VLGameProject.VLInput {
    public class InputComponentProgramExample : ABSInputComponent {

        [Header("GameInputProgram-Event")]
        public UltEvent On_ProgramPauseResume_Press;

        public UltEvent On_ProgramQuickSave_Press;
        public UltEvent On_ProgramQuickLoad_Press;

        public UltEvent On_GuiNavigationMoveUp_Press;
        public UltEvent On_GuiNavigationMoveDown_Press;
        public UltEvent On_GuiNavigationMoveLeft_Press;
        public UltEvent On_GuiNavigationMoveRight_Press;
        public UltEvent On_GuiNavigationConfirm_Press;
        public UltEvent On_GuiNavigationBack_Press;

        public override void GameInput_Init(InputManager arg_inputManager) {
            //Bind to InputManager
            arg_inputManager.OnInputContextPress += InputContext_Press;

            //Add persistance call Get_GameProgram().Do_Resume() to On_ProgramResume_Press
            On_ProgramPauseResume_Press += InputWrapper.GameProgram_PauseResume;
            On_ProgramQuickSave_Press += InputWrapper.MemoryCard_GameData_QuickSave;
            On_ProgramQuickLoad_Press += InputWrapper.MemoryCard_GameData_QuickLoad;
        }

        public override void GameInput_Clean(InputManager arg_inputManager) {
            throw new NotImplementedException();
        }

        public override void InputContext_Press(ENUM_INPUT_CONTEXT arg_type) {
            switch (arg_type) {
                case ENUM_INPUT_CONTEXT.K_NONE:
                    break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_PAUSERESUME_TOGGLE: On_ProgramPauseResume_Press?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKSAVE: On_ProgramQuickSave_Press?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKLOAD: On_ProgramQuickLoad_Press?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVEUP: On_GuiNavigationMoveUp_Press?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVEDOWN: On_GuiNavigationMoveDown_Press?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVELEFT: On_GuiNavigationMoveLeft_Press?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_MOVERIGHT: On_GuiNavigationMoveRight_Press?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_CONFIRM: On_GuiNavigationConfirm_Press?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_PROGRAM_GUINAVIGATION_BACK: On_GuiNavigationBack_Press?.Invoke(); break;
                default:
                    break;
            }
        }

        public override void InputContext_Hold(ENUM_INPUT_CONTEXT arg_type) { }
        public override void InputContext_Release(ENUM_INPUT_CONTEXT arg_type) { }                
    }
}
