using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_GAMEMODE_TYPE {
    NORMAL,
    TIMEATTACK
}

public enum ENUM_GAMEOVER_TYPE {
    WIN,
    LOSE
}

public class ManagerGame : SingletonBlank<ManagerGame> {
    [SerializeField] private ENUM_GAMEMODE_TYPE enum_gameModeType;
    [SerializeField] private ENUM_GAMEOVER_TYPE enum_gameOverType;

    private bool isGameOver = false;

    private void Start() => OnGameStart(enum_gameModeType);
    private void Update() => OnGameLoop(enum_gameModeType);

    public bool IsGameMode(ENUM_GAMEMODE_TYPE _gameModeType) { return enum_gameModeType == _gameModeType; }

    public void SetGameOverStatus(bool _status, ENUM_GAMEOVER_TYPE _type) { 
        isGameOver = _status;
        enum_gameOverType = _type;
    }

    public void OnGameStart(ENUM_GAMEMODE_TYPE _type) {
        Time.timeScale = 1.0f;

        switch (_type) {
            case ENUM_GAMEMODE_TYPE.NORMAL: break;
            case ENUM_GAMEMODE_TYPE.TIMEATTACK: break;
            default: break;
        }
    }

    public void OnGameLoop(ENUM_GAMEMODE_TYPE _type) {
        //Check if game is over
        if (isGameOver) {
            OnGameEnd(enum_gameModeType, enum_gameOverType);
            return;
        }
        
        switch (_type) {
            case ENUM_GAMEMODE_TYPE.NORMAL: break;
            case ENUM_GAMEMODE_TYPE.TIMEATTACK: break;
            default: break;
        }
    }

    public void OnGameEnd(ENUM_GAMEMODE_TYPE _type, ENUM_GAMEOVER_TYPE _gameoverType) {
        Time.timeScale = 0.0f;

        switch (_gameoverType) {
            case ENUM_GAMEOVER_TYPE.WIN:
                switch (_type) {
                    case ENUM_GAMEMODE_TYPE.NORMAL:
                        GUIManager.Instance.OpenGUIPage(ENUM_GUIPAGE.WIN);                        
                        break;
                    case ENUM_GAMEMODE_TYPE.TIMEATTACK:
                        GUIManager.Instance.OpenGUIPage(ENUM_GUIPAGE.WIN);                        
                        break;
                    default: break;
                }
                break;
            case ENUM_GAMEOVER_TYPE.LOSE:
                switch (_type) {
                    case ENUM_GAMEMODE_TYPE.NORMAL:
                        GUIManager.Instance.OpenGUIPage(ENUM_GUIPAGE.LOSE);                        
                        break;
                    case ENUM_GAMEMODE_TYPE.TIMEATTACK:
                        GUIManager.Instance.OpenGUIPage(ENUM_GUIPAGE.LOSE);                        
                        break;
                    default: break;
                }
                break;
            default: break;
        }        
    }
}
