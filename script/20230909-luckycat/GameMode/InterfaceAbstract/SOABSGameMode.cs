using UltEvents;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGameMode {

    interface IGameScene {
        void GameScene_Start();
    }

    interface IGameRule {
        //void GameRule_Restart(GameProgram _gameProgram);
        //void GameRule_Process(GameProgram _gameProgram); NOT SURE ABOUT THE ROLE
        //void GameRule_End(GameProgram _gameProgram);
        void GameRule_Setup(GameModeManager arg_gameModeManager);
        void GameRule_Process(GameModeManager arg_gameModeManager);
        void GameRule_Resolve(GameModeManager arg_gameModeManager);
        //Add Process
    }

    interface IGameState {
        void GameState_RestartToCheckpoint(GameModeManager arg_gameModeManager);
        void GameState_Restart(GameModeManager arg_gameModeManager);
        void GameState_Init(GameModeManager arg_gameModeManager);
        void GameState_Start(GameModeManager arg_gameModeManager);
        void GameState_Loop(GameModeManager arg_gameModeManager);
        void GameState_End(GameModeManager arg_gameModeManager);
    }

    public abstract class SOABSGameMode : ScriptableObject, IGameRule, IGameState {

        //TODO - Not sure if needed events for such a thing
        [Header("Event")]
        public UltEvent On_GameScene_Setup;

        public UltEvent On_GameRule_Setup;
        public UltEvent On_GameRule_Process;
        public UltEvent On_GameRule_Resolve;

        public UltEvent On_GameState_Restart;
        public UltEvent On_GameState_RestartToCheckpoint;
        public UltEvent On_GameState_Init;
        public UltEvent On_GameState_Start;
        public UltEvent On_GameState_Loop;
        public UltEvent On_GameState_End;

        //--VARIABLE--
        public bool isGameRuleSetupComplete;
        public bool isGameRuleResolveComplete;
        public bool IsGameRuleSetupComplete() { return isGameRuleSetupComplete; }
        public bool IsGameRuleResolveComplete() { return isGameRuleResolveComplete; }
        public void Set_IsGameRuleSetupComplete(bool _status) => isGameRuleSetupComplete = _status;
        public void Set_IsGameRuleResolveComplete(bool _status) => isGameRuleResolveComplete = _status;

        //--GAMERULE--
        /// <summary>
        /// Set up the gameplay, call when needed
        /// </summary>    
        public abstract void GameRule_Setup(GameModeManager arg_gameModeManager);

        /// <summary>
        /// Update along GameMode
        /// </summary>    
        public abstract void GameRule_Process(GameModeManager arg_gameModeManager);

        /// <summary>
        /// Run only once in GameModeEnd
        /// </summary>        
        public abstract void GameRule_Resolve(GameModeManager arg_gameModeManager);

        //--GAMESTATE--
        public abstract void GameState_Restart(GameModeManager arg_gameModeManager);
        public abstract void GameState_RestartToCheckpoint(GameModeManager arg_gameModeManager);
        public abstract void GameState_Init(GameModeManager arg_gameModeManager);
        public abstract void GameState_Start(GameModeManager arg_gameModeManager);
        public abstract void GameState_Loop(GameModeManager arg_gameModeManager);
        public abstract void GameState_End(GameModeManager arg_gameModeManager);
    }
}