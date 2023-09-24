using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ALL STATIC FUNCTIONS LIKE PlayerPrefX
public class SaveDataMNG
{
    public static void InitSaveGame1stTime()
    {
        //Check is game init the first time on this system
        if (!Load_IsSaveGameInit1stTime())
        {
            //Reset to default
            ResetSaveData();
        }
    }

    public static void ResetSaveData()
    {
        //Do not check it again
        Save_IsSaveGameInit1stTime(true);
        
        //Init Monitor
        Save_OptionsMonitorType(4);

        //Init all mixer
        Save_OptionsMixerMaster(0.5f);
        Save_OptionsMixerMusic(0.5f);
        Save_OptionsMixerSFX(0.5f);
        Save_OptionsMixerSFX_UI(0.5f);
        Save_OptionsMixerSFX_GAME(0.5f);

        //Set up Monitor after all settings done saving
        Load_OptionsMonitorType();
    }

    #region SAVE_FUNCTIONS

    public static void Save_IsSaveGameInit1stTime(bool status)
    {
        PlayerPrefsX.SetBool(ProjectConstants.SAVEDATA_INIT_GAME_SETUP, status);
    }

    public static void Save_GameCurrency(int value)
    {
        PlayerPrefs.SetInt(ProjectConstants.SAVEDATA_GAME_CURRENCY, value);

        CurrencyManager.Instance.coin = Load_GameCurrency();

        GUIManager.Instance.UpdateText(ENUM_UI_TEXT_TYPE.CURRENCY_COIN);
    }

    //GAME SETTINGS RELATED
    public static void Save_OptionsMonitorType(int id)
    {
        //Insert all code function here
        PlayerPrefs.SetInt(ProjectConstants.SAVEDATA_OPTIONS_MONITOR_TYPE, id);
    }

    public static void Save_OptionsMixerMaster(float value)
    {
        PlayerPrefs.SetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_MasterVol.ToString(), value);
    }

    public static void Save_OptionsMixerMusic(float value)
    {
        PlayerPrefs.SetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_MusicVol.ToString(), value);
    }

    public static void Save_OptionsMixerSFX(float value)
    {
        PlayerPrefs.SetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFXVol.ToString(), value);
    }

    public static void Save_OptionsMixerSFX_UI(float value)
    {
        PlayerPrefs.SetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_UIVol.ToString(), value);
    }

    public static void Save_OptionsMixerSFX_GAME(float value)
    {
        PlayerPrefs.SetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_GameVol.ToString(), value);
    }    

    #endregion

    #region LOAD_FUNCTIONS    

    public static bool Load_IsSaveGameInit1stTime()
    {
        return PlayerPrefsX.GetBool(ProjectConstants.SAVEDATA_INIT_GAME_SETUP);
    }
    
    public static void Load_OptionsMonitorType()
    {
        int id = PlayerPrefs.GetInt(ProjectConstants.SAVEDATA_OPTIONS_MONITOR_TYPE);

        //Set resolution
        Screen.SetResolution(ProjectConstants.screen_Widths[id], ProjectConstants.screen_Heights[id], false, 60);
    }

    public static float Load_OptionsMixerMaster()
    {
        return PlayerPrefs.GetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_MasterVol.ToString());
    }

    public static float Load_OptionsMixerMusic()
    {
        return PlayerPrefs.GetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_MusicVol.ToString());
    }

    public static float Load_OptionsMixerSFX()
    {
        return PlayerPrefs.GetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFXVol.ToString());
    }

    public static float Load_OptionsMixerSFX_UI()
    {
        return PlayerPrefs.GetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_UIVol.ToString());
    }

    public static float Load_OptionsMixerSFX_Game()
    {
        return PlayerPrefs.GetFloat(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_GameVol.ToString());
    }

    public static float Load_OptionsSpecificMixer(ENUM_MIXER_GROUP_NAME mixerType)
    {
        return PlayerPrefs.GetFloat(mixerType.ToString());
    }

    public static int Load_GameCurrency()
    {
        return PlayerPrefs.GetInt(ProjectConstants.SAVEDATA_GAME_CURRENCY);
    }

    #endregion
}
