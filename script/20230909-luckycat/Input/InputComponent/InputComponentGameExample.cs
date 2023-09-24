using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;
using VLGameProject.Tool;

namespace VLGameProject.VLInput {
    public class InputComponentGameExample : ABSInputComponent {

        public UltEvent On_PlayerMoveUp_Hold;
        public UltEvent On_PlayerMoveUp_Release;

        public UltEvent On_PlayerMoveDown_Hold;
        public UltEvent On_PlayerMoveDown_Release;

        public UltEvent On_MoveLeft_Hold;
        public UltEvent On_MoveLeft_Release;

        public UltEvent On_MoveRight_Hold;
        public UltEvent On_MoveRight_Release;

        public UltEvent On_Attack_Hold;
        public UltEvent On_Attack_Release;

        public UltEvent On_Special_Hold;
        public UltEvent On_Special_Release;

        public override void GameInput_Init(InputManager arg_inputManager) {
            //IMPORTANT - Announce and Bind to InputManager
            arg_inputManager.OnInputContextPress += InputContext_Press;
            arg_inputManager.OnInputContextHold += InputContext_Hold;
            arg_inputManager.OnInputContextRelease += InputContext_Release;

            GameComponentMovement movement = this.gameObject.IsNullGetComponent<GameComponentMovement>(this);
            if (movement != null) {
                On_PlayerMoveUp_Hold += movement.MoveUp;
                On_PlayerMoveUp_Release += movement.Movement_Reset;

                On_PlayerMoveDown_Hold += movement.MoveDown;
                On_PlayerMoveDown_Release += movement.Movement_Reset;

                On_MoveLeft_Hold += movement.MoveLeft;
                On_MoveLeft_Release += movement.Movement_Reset;

                On_MoveRight_Hold += movement.MoveRight;
                On_MoveRight_Release += movement.Movement_Reset;
            }            
        }

        public override void GameInput_Clean(InputManager arg_inputManager) {
            //IMPORTANT - Must disable the bind when destroyed
            arg_inputManager.OnInputContextPress -= InputContext_Press;
            arg_inputManager.OnInputContextHold -= InputContext_Hold;
            arg_inputManager.OnInputContextRelease -= InputContext_Release;

            On_PlayerMoveUp_Hold.Clear();
            On_PlayerMoveUp_Release.Clear();
            On_PlayerMoveDown_Hold.Clear();
            On_PlayerMoveDown_Release.Clear();
            On_MoveLeft_Hold.Clear();
            On_MoveLeft_Release.Clear();
            On_MoveRight_Hold.Clear();
            On_MoveRight_Release.Clear();
        }

        public override void InputContext_Press(ENUM_INPUT_CONTEXT arg_type) {
            switch (arg_type) {
                case ENUM_INPUT_CONTEXT.K_NONE:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVEUP:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVEDOWN:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVELEFT:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVERIGHT:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_ATTACK:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_DEFEND:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_FEVER:
                    break;
                default:
                    break;
            }
        }

        public override void InputContext_Hold(ENUM_INPUT_CONTEXT arg_type) {
            switch (arg_type) {
                case ENUM_INPUT_CONTEXT.K_NONE:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVEUP: On_PlayerMoveUp_Hold?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVEDOWN: On_PlayerMoveDown_Hold?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVELEFT: On_MoveLeft_Hold?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVERIGHT: On_MoveRight_Hold?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_ATTACK:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_DEFEND:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_FEVER:
                    break;
                default:
                    break;
            }
        }

        public override void InputContext_Release(ENUM_INPUT_CONTEXT arg_type) {
            switch (arg_type) {
                case ENUM_INPUT_CONTEXT.K_NONE:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVEUP: On_PlayerMoveUp_Release?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVEDOWN: On_PlayerMoveDown_Release?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVELEFT: On_MoveLeft_Release?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_MOVERIGHT: On_MoveRight_Release?.Invoke(); break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_ATTACK:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_DEFEND:
                    break;
                case ENUM_INPUT_CONTEXT.K_GAME_PLAYER_FEVER:
                    break;
                default:
                    break;
            }
        }        
    }
}
