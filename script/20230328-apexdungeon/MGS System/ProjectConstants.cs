using System.Collections;
using System.Collections.Generic;

#region SUMMARY
/* MAIN INFO
Name: BUI CHAU HOANG LONG
Date: 18-4-2021

Script Summary:   
Game Settings when change will the game change drastically 
and sometime unstable so be caution!
*/
#endregion

public enum ENUM_SCENE_NAME
{
    SPLASH_SCREEN,
    MAIN_MENU,
    GAMEPLAY,
    TUTORIAL
}

public enum ENUM_GAME_END_TYPE
{
    NONE_DRAW,
    WIN,
    LOSE
}

public enum ENUM_GAME_MODE_TYPE
{
    NONE
}

public enum ENUM_AUDIO_SFX_UI_TYPE
{    
    UI_TRANSITION,        
    SELECT,
    HOVER,
    CONFIRM,
    BACK_CANCEL,
    OPEN_DROPDOWN,
    WARNING_ALERT_REQUEST                
}

public enum ENUM_AUDIO_SFX_TYPE
{
    GUN,
    HIT_IMPACT,
    ENEMY_DEATH,
    FOOTSTEP,
    TUNG_DEATH_01,
    TUNG_DEATH_02,
    TUNG_DEATH_03,
    TUNG_DEATH_04
}

public enum ENUM_AUDIO_MUSIC_TYPE
{
    //BACKGROUND
    MAIN_MENU,
    MAIN_MENU_V2,
    BATTLE_00,
    BATTLE_01,
    BATTLE_02,
    BOSS,
    GAME_OVER,
    BATTLE_03
}

public enum ENUM_DATABASE_TYPE
{
    CAR_DATA,
    RACETRACK_DATA
}

public enum ENUM_MIXER_GROUP_NAME
{
    Options_Mixer_MasterVol,
    Options_Mixer_MusicVol,
    Options_Mixer_SFXVol,
    Options_Mixer_SFX_UIVol,
    Options_Mixer_SFX_GameVol
}

public enum ENUM_UI_PAGES_ID
{
    NONE,
    CREDIT_SCREEN,
    MAIN_MENU,
    HOW_TO_PLAY,
    OPTIONS,
    //For Gameplay only
    GAMEPLAY_NORMAL,
    //System Pause
    PAUSE_GAME,
    GAME_OVER, //DIRECT TO REQUEST PAGE
    ASK_CONFIRMATION //DIRECT TO REQUEST PAGE
}

public enum ENUM_UI_REQUEST_PAGE_ID
{
    NONE,
    GAME_OVER_NONE_DRAW,
    GAME_OVER_WIN,
    GAME_OVER_LOSE,
    CONFIRMATION_RETRY,
    CONFIRMATION_QUIT_TO_MAIN_MENU,
    CONFIRMATION_QUIT_TO_OS
}

public enum ENUM_DROPDOWN_TYPE
{
    EXAMPLE,
    OPTIONS_SCREEN_RESOLUTIONS
}

public enum ENUM_UI_SLIDER_TYPE
{
    NONE,
    //Audio Settings
    OPTIONS_MIXER_MASTER,
    OPTIONS_MIXER_MUSIC,
    OPTIONS_MIXER_SFX,
    OPTIONS_MIXER_SFX_UI,
    OPTIONS_MIXER_SFX_CAR
}

public enum ENUM_UI_BUTTON_TYPE
{
    EXAMPLE_TEST,
    //MAIN MENU PAGE    
    GO_TO_NEXT_PAGE,
    BACK_PAGE,
    CLOSE_PAGE,
    GOTO_PAGE_HOW_TO_PLAY,
    GOTO_PAGE_OPTIONS,
    GOTO_PAGE_CREDIT,
    GOTO_LEVEL_GAMEPLAY,
    GOTO_LEVEL_TUTORIAL,
    FUNCTION_RESUME,
    FUNCTION_PAUSE_GAME,    
    //COFIRMATIONS BUTTON
    ASK_QUIT_TO_MAIN_MENU,
    FUNCTION_QUIT_TO_MAIN_MENU,
    ASK_QUIT_TO_OS,
    FUNCTION_QUIT_TO_OS,
    ASK_RESET_SAVE_DATA,
    FUNCTION_RESET_SAVE_DATA,
    //OTHER BUTTONS
    SHOP_ITEM,
    SHOP_SKILL_ITEM,
    SHOP_UPGRADE_ITEM,
    SHOP_ATTACH_ITEM,
    FUNCTION_RESTART_GAME
}

public enum ENUM_UI_TEXT_TYPE
{
    NONE,
    //Options Settings
    OPTIONS_MIXER_MASTER,
    OPTIONS_MIXER_MUSIC,
    OPTIONS_MIXER_SFX,
    OPTIONS_MIXER_SFX_UI,
    OPTIONS_MIXER_SFX_CAR,
    CURRENCY_COIN
}

public enum ENUM_UI_ELEMENTS_STATUS
{
    MOUSE_CLICKS_ONCE,
    MOUSE_CLICKS_ONGOING,
    MOUSE_RELEASE,
    ENTER,
    HOVER_UPDATE,
    EXIT
}

public enum ENUM_UI_POPULATE_TYPE
{
    NONE,
    EXAMPLE,
    SHOP_ITEM,
    SHOP_UPGRADE,
    SHOP_SKILLS,
    SHOP_ATTACHMENT
}

public enum ENUM_SHOP_ITEM_TYPE
{
    HEALTH_POTION,
    MANA_POTION
}

/*
public enum ENUM_SHOP_SKILL_ITEM_TYPE
{
    DASH,
    INVUL,
    TIME_STOP
}

public enum ENUM_SHOP_UPGRADE_ITEM_TYPE
{
    ATK,
    DEF,
    SPD
} 
 */

public enum ENUM_SHOP_ATTACHMENT_ITEM_TYPE
{
    SHOTGUN,
    SPEED,
    FIRE,
    WATER,
    ELECTRIC,
    POISON
}

public class ProjectConstants
{
    #region TAGS & PROJECT
    public const string TAG_PLAYER = "Player";

    public const int PLAYER_DEFAULT_MONEY = 1000;
    public const float PLAYERSTAT_DEFAULT_HEALTH = 100.0f;
    public const float PLAYERSTAT_DEFAULT_STAMINA = 100.0f;

    public const float AUTO_DESTROY_TIME = 10.0f;    
    #endregion

    #region PROJECT RELATED
    public const float PLANT_STAT_MAX_VALUE = 128.0f;
    public const float PLANT_STAT_MIN_VALUE = 0.0f;
    public const float PLANT_PROGRESS_1ST_STAGE = 51.2f; //128.0f * 2/5
    public const float PLANT_PROGRESS_2ND_STAGE = 102.4f; //128.0f * 4/5
    public const float PLANT_PROGRESS_FINAL_STAGE = 128.0f;
    #endregion

    #region DEBUG MESSAGES
    public static bool SHOW_DEBUG_MESSAGE_ALL = false; //Default: true
    public static bool SHOW_FRAMEWORKSYSTEM_DEBUG_MESSAGE = false; //Default: true
    public static bool SHOW_GAMEPLAYMANAGER_DEBUG_MESSAGE = false; //Default: true
    public static bool SHOW_GAMESCENE_DEBUG_MESSAGE = false; //Default: true
    //Ignore all debug settings above force though it
    public static bool ALLOW_FORCE_DEBUG_MESSAGE = false; //Default: false, must disable for release version
    #endregion DEBUG MESSAGES

    #region SYSTEM FUNCTIONALITIES
    public static bool ENABLE_SYSFUNCTION_UI_MOUSE_CLICK_ONCE = true; //Default: true
    public static bool ENABLE_SYSFUNCTION_UI_MOUSE_CLICK_ONGOING = false; //Default: false
    public static bool ENABLE_SYSFUNCTION_UI_RELEASE = false; //Default: false
    public static bool ENABLE_SYSFUNCTION_UI_ENTER = true; //Default: true
    public static bool ENABLE_SYSFUNCTION_UI_HOVER_UPDATE = true; //Default: false
    public static bool ENABLE_SYSFUNCTION_UI_EXIT = true; //Default: false

    public static bool ENABLE_PAUSE_VIA_KEY_PRESS = true; //Default: false
    public static bool ENABLE_RESTART_VIA_KEY_PRESS = false; //Default: false
    #endregion

    #region AUDIO STUFF
    public const float MGS_AUDIO_RATE = 20.0f; //Default: 20.0f
    public const float MGS_AUDIO_RATE_MUTE = 80.0f; //Default: 80.0f
    public const float AUDIO_SLIDER_MIN = 0.0f; //Default: 0.0f    
    public const float AUDIO_SLIDER_MAX = 1.0f; //Default: 1.0f
    public const float AUDIO_SLIDER_DEFAULT = 0.5f; //Default: 0.5f
    #endregion

    #region MASTER_GAME_SYSTEM    
    public static bool ENABLE_MGS_SYSTEM = true; //Always leave it as false, unless testing cetain things
    public const float MGS_COUNTDOWN_INVOKE_REPEAT = 1.0f;
    public const float MGS_COUNTDOWN_GAME_START_TIME = 5.0f;
    
    #endregion

    #region SAVEDATA TAGS
    public const string SAVEDATA_INIT_GAME_SETUP = "isGameInit_1stTime";
    public const string SAVEDATA_OPTIONS_MONITOR_TYPE = "Options_MonitorType";
    public const string SAVEDATA_GAME_CURRENCY = "Game_Currency";
    #endregion

    //The screen resolution
    #region OPTIONS SETTINGS
    public const bool ALLOW_SCREEN_FULLSCREEN_MODE = false; //Default: false
    public static bool ALLOW_SCREEN_PORTRAIT_MODE = false; //Default: false, switch Widths to Heights and vice versa
    public static List<int> screen_Widths = new List<int>() { 640, 800, 1280, 1366, 1920 };
    public static List<int> screen_Heights = new List<int>() { 480, 600, 720, 768, 1080 };
    #endregion
}

