using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_DEBUG_TYPE
{
    NORMAL,
    WARNING,
    ERROR
}

public enum ENUM_DEBUG_CATALOG
{
    FRAMEWORK_SYSTEM,
    GAMEPLAY_MANAGER,
    GAMEPLAY_SCENE
}

public class DebugSystem : Singleton_Persist<DebugSystem>
{
    #region DEBUG MESSAGES
    //DO NOT EDIT

    public static void Message(string message, ENUM_DEBUG_CATALOG catalogType
    , ENUM_DEBUG_TYPE messageType = ENUM_DEBUG_TYPE.NORMAL)
    {
        //Check debug exceptions
        if (ProjectConstants.SHOW_FRAMEWORKSYSTEM_DEBUG_MESSAGE == false && catalogType == ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM) return;
        if (ProjectConstants.SHOW_GAMEPLAYMANAGER_DEBUG_MESSAGE == false && catalogType == ENUM_DEBUG_CATALOG.GAMEPLAY_MANAGER) return;
        if (ProjectConstants.SHOW_GAMESCENE_DEBUG_MESSAGE == false && catalogType == ENUM_DEBUG_CATALOG.GAMEPLAY_SCENE) return;

        //Show all message
        if (ProjectConstants.SHOW_DEBUG_MESSAGE_ALL)
        {
            //If there are no exception, then continue debug message
            switch (messageType)
            {
                case ENUM_DEBUG_TYPE.NORMAL:
                    Debug.Log(message);
                    break;

                case ENUM_DEBUG_TYPE.WARNING:
                    Debug.LogWarning(message);
                    break;

                case ENUM_DEBUG_TYPE.ERROR:
                    Debug.LogError(message);
                    break;

                default:
                    break;
            }
        }
    }

    public static void MessageForceMode(string message, ENUM_DEBUG_CATALOG catalogType
    , ENUM_DEBUG_TYPE messageType = ENUM_DEBUG_TYPE.NORMAL)
    {
        //Check if the features allow
        if (ProjectConstants.ALLOW_FORCE_DEBUG_MESSAGE == false) return;

        //If allow this feature and there are no exception, then continue debug message
        switch (messageType)
        {
            case ENUM_DEBUG_TYPE.NORMAL:
                Debug.Log(message);
                break;

            case ENUM_DEBUG_TYPE.WARNING:
                Debug.LogWarning(message);
                break;

            case ENUM_DEBUG_TYPE.ERROR:
                Debug.LogError(message);
                break;

            default:
                break;
        }
    }

    #endregion DEBUG MESSAGES

    public static void CheckingFeaturesFromProjectConst()
    {
        //Use of tenary expression to call functions
        (ProjectConstants.ENABLE_MGS_SYSTEM == true ?
        new System.Action(() => Message("MGS Framework is running !! Testing Framework switched off.", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.ERROR)) :
        new System.Action(() => Message("Testing Framework is running !! MGS Framework has been switched off.", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.ERROR))
        )();

        (ProjectConstants.ENABLE_PAUSE_VIA_KEY_PRESS == true ?
        new System.Action(() => Message("Pause Feature Via Key Press enabled !!", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.WARNING)) :
        new System.Action(() => Message("Pause Feature Via Key Press disabled !!", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.WARNING))
        )();        

        (ProjectConstants.ENABLE_RESTART_VIA_KEY_PRESS == true ?
        new System.Action(() => Message("Restart Feature Via Key Press enabled !!", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.WARNING)) :
        new System.Action(() => Message("Restart Feature Via Key Press disabled !!", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.WARNING))
        )();

        (SaveDataMNG.Load_IsSaveGameInit1stTime() == true ?
        new System.Action(() => Message("SaveGame already init 1st time.", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.WARNING)) :
        new System.Action(() => Message("SaveGame is not init 1st time.", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.WARNING))
        )();
    }
}
