using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLLocalization {

    public enum ENUMLocalizationLanguage {
        K_None = 0,
        K_English_en,
        K_Vietnamese_vi,
        K_German_de,
        K_Russian_ru,
        K_Chinese_zh,
        K_Japanese_ja,
        K_Korean_ko,
    }    

    [CreateAssetMenu(fileName = "New LocalizationLanguage-LanguageCode", menuName = "VLGameProject/Localization/New LocalizationLanguage-LanguageCode")]
    public class SOLocalization : ScriptableObject {

        [ContextMenu("VL_EditorReset")]
        public void VL_EditorReset() {
            //access to csv file
            //auto update specific word

            //safe-check
            if(isConsent == false) {
                Debug.LogWarning($"PLEASE CHECK AGAIN BEFORE DOING STUPID !! {nameof(isConsent)} {isConsent} {enum_language.ToString()} ");
                return;
            }

            Debug.Log($"Start NOW !! Load from Localization File, Setting to {enum_language.ToString()}");
            isConsent = false;
        }

        [Header("EditorReset-BECAREFUL")]
        public ENUMLocalizationLanguage enum_language;
        public bool isConsent;

        [Header("Other")]
        public string str_hello;
        public string str_greeting;

        [Header("GameInfo")]
        public string str_copyright;
        public string str_version;

        [Header("MainMenu")]
        public string str_pressAnyKey;
        public string str_startGame;
        public string str_loadGame;        
        public string str_gallery;
        public string str_option;
        public string str_credit;        
        public string str_mainMenuAchievement;        
        public string str_exitToOs;        

        [Header("GameMode")]
        public string str_gameModeTimeLimit;
        public string str_gameWin;
        public string str_gameDraw;
        public string str_gameOver;

        [Header("Gui")]
        public string str_guiInfo;
        public string str_guiWarning;
        public string str_guiCaution;
        public string str_guiError;
        public string str_guiYes;
        public string str_guiNo;
        public string str_guiAccept;
        public string str_guiCancel;

        [Header("Gui-Ask")]
        public string str_askRestartGame;
        public string str_askRestartCheckpoint;
        public string str_askSaveGame;        
        public string str_askLoadGame;        
        public string str_askBackToMainMenu;
        public string str_askExitToMainMenu;
        public string str_askExitToOS;

        [Header("Multiplayer")]
        public string str_mpJoinGame;

        [Header("Server")]
        public string str_serverNew;
        public string str_serverStop;

        [Header("Account")]
        public string str_accountFirstName;
        public string str_accountMiddleName;
        public string str_accountLastName;
        public string str_accountNickname;

        [Header("Email")]
        public string str_email;
        public string str_emailAlreadyExist;
        public string str_emailCannotExceed255Character;
        public string str_emailIsNotValid;
        public string str_emailIsValid;
        public string str_emailCreateSuccess;
        public string str_emailCreateFail;

        [Header("Social")]
        public string str_chat;
        public string str_chatUnableToConnect;

        public string k_something;
    }
}
