using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;
using VLGameProject.VLGameMode;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGameMode {
    public enum ENUM_GAMEEND {
        K_NONE = 0,
        K_DRAW = 1,
        K_WIN = 2,
        K_LOSE = 3
    }

    /// <summary>
    /// Game Mode Manager, it just need to know what game mode it supposed to play
    /// </summary>
    public class GameModeManager : GameProgramObject {

        //Unreal Engine Style - From Game Mode to Game Rule
        //Player Class
        //Spectator When Lose
        //Gui Class
        //Player Start Position
        //Game State
        [Header("GameModeManager")]
        public SOABSGameMode m_gameMode;

        public ENUM_GAMEEND enum_gameEndType;

        public bool isGameStart = false;
        public bool isGameEnd = false;

        public override void Awake() {
            base.Awake();
            GameMode_Init();
        }
        public override void Start() {
            base.Start();
            GameMode_Start();
        }
        public override void Update() {
            base.Update();
            GameMode_Loop();
        }

        public bool IsGameModeType(SOABSGameMode _gameModeType) { return m_gameMode == _gameModeType; }
        public SOABSGameMode Get_GameMode() { return m_gameMode; }

        public void Set_GameOver(bool arg_isGameEnd, ENUM_GAMEEND _type) {
            Set_IsGameStart(false);
            Set_IsGameEnd(arg_isGameEnd);
            enum_gameEndType = _type;
        }
        public bool IsGameStart() { return isGameStart; }
        public bool IsGameEnd() { return isGameEnd; }
        public void Set_IsGameStart(bool arg_status) => isGameStart = arg_status;
        public void Set_IsGameEnd(bool arg_status) => isGameEnd = arg_status;

        public void GameMode_Init() => Get_GameMode().GameState_Init(this);
        public void GameMode_Start() {
            Get_GameMode().GameRule_Setup(this);
            Get_GameMode().GameState_Start(this);
        }
        public void GameMode_Loop() {
            if (Get_GameProgram().IsGameProgramPause() == false)
                return;

            if (isGameStart) {
                if (IsGameEnd()) {
                    GameMode_End();
                    return; //early-exit
                }

                Get_GameMode().GameRule_Process(this);
                Get_GameMode().GameState_Loop(this);
            }
        }
        public void GameMode_End() {
            Set_IsGameStart(false);
            Get_GameMode().GameState_End(this);
        }
    }
}

