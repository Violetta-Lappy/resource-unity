using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameMode;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGameMode {
    [CreateAssetMenu(fileName = "New GameMode-Empty", menuName = "GameMode/New GameMode-Empty")]
    public class GameModeEmpty : SOABSGameMode {
        [Header("Data")]
        public GameDataEmpty m_gameDataEmpty;
        public GameDataEmpty Get_GameDataEmpty() { return m_gameDataEmpty; }

        //Game Rule    
        public override void GameRule_Setup(GameModeManager arg_gameModeManager) { }
        public override void GameRule_Process(GameModeManager arg_gameModeManager) { }
        public override void GameRule_Resolve(GameModeManager arg_gameModeManager) { }

        //Game State
        public override void GameState_Restart(GameModeManager arg_gameModeManager) {
            throw new System.NotImplementedException();
        }
        public override void GameState_RestartToCheckpoint(GameModeManager arg_gameModeManager) { }
        public override void GameState_Init(GameModeManager arg_gameModeManager) { }
        public override void GameState_Start(GameModeManager arg_gameModeManager) {
            Debug.Log(Get_GameDataEmpty().Get_HelloMessage());
        }
        public override void GameState_Loop(GameModeManager arg_gameModeManager) { }
        public override void GameState_End(GameModeManager arg_gameModeManager) { }
    }
}

