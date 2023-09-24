/*
Copyright (C) 2023 hoanglongplanner 

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.

You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

// (C) 2023 hoanglongplanner
// Managing all type of GUIs in game
// Thanks, I hate it
// UI Development is hellish

using VLGameProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using VLGameProject.VLGameProgram;
using VLGameProject.VLSceneManagement;

namespace VLGameProject.VLGui {

    public enum ENUM_GUIELEMENT_POINTER {
        K_NONE = 0,
        K_ON_ENTER = 1,
        K_ON_HOVER = 2,
        K_ON_EXIT = 3,
        K_ON_MOUSE_DOWN = 4,
        K_ON_MOUSE_HOLD = 5,
        K_ON_MOUSE_RELEASE = 6
    }    
    
    public enum ENUM_GUIMODAL {
        K_NOTIFICATION_INFO = 50,
        K_NOTIFICATION_CAUTION = 50,
        K_NOTIFICATION_WARNING = 50,
        K_NOTIFICATION_ERROR = 50,

        //COMMON
        K_ASK_RESTART_GAME = 0,
        K_ASK_EXIT_TO_MAINMENU = 1,
        K_ASK_EXIT_TO_OS = 2,

        //GAMEPLAY-MODALS
        K_PAGE_GAMEPLAY_MODAL_TUTORIAL,

        //UNCOMMON
        K_PAGE_GAMEPLAY_RESULT_OVERVIEW_MODAL = 10,

        K_SHOP_BUY,
        K_SHOP_SELL,

        K_ASK_SKIP_CUTSCENE = 50,

        K_GAMEPLAY_PLAYER_STATUS = 100,
        K_GAMEPLAY_TEAM_MEMBER_STATUS = 100,
        K_GAMEPLAY_MONEY,
        K_GAMEPLAY_MINIMAP,
        K_GAMEPLAY_QTE,

        //MEMORYCARD-ASK
        K_ASK_MEMORYCARD_SAVE,
        K_ASK_MEMORYCARD_LOAD,
        K_ASK_MEMORYCARD_DELETE,

        //IAP
        K_ASK_IAP_BUY,
        K_ASK_IAP_SELL,
    }

    public enum ENUM_GUIELEMENT_POPULATE {
        //COMMON
        K_WINDOW_RESOLUTION = 0,
        K_WINDOW_TYPE = 1,

        //UNIQUE
        K_SHOP_CONSUMABLES,
        K_SHOP_ITEMS,
        K_IAP
    }

    public enum ENUM_GUIELEMENT_OBJECT {
        //UNIQUE
        K_TIMER,
        K_DISABLE_INPUT_INFO,
    }

    public enum ENUM_GUIELEMENT_SLIDER {
        K_NONE = 0,

        //COMMON
        K_AUDIO_MIXER_MASTER = 1,
        K_AUDIO_MIXER_MUSIC = 128,
        K_AUDIO_MIXER_SFX = 256,
        K_AUDIO_MIXER_SFX_UI,
        K_AUDIO_MIXER_SFX_GAME,
        K_AUDIO_MIXER_VOCAL = 384, //VOCAL-MIXER-FOR-EVERY-CHARACTER
        K_AUDIO_MIXER_VOICE_COMMUNICATIONS = 512, //VOCAL-MIXER-FOR-EVERY-CHARACTER

        //UNIQUE
        K_GAME_FEVER = 200,
    }    

    public class GuiManager : Singleton<GuiManager> {
        public ENUMGuiPage enum_pageCurrent;
        public ENUMGuiPage enum_pagePrevious;
        public List<GuiPage> list_m_guiPage;
        public List<GuiPopulate> list_m_guiPopulate;
        public List<GuiElementObject> list_m_guiObject;
        public List<GuiText> list_m_guiText;
        public List<GuiButton> list_m_guiButton;
        public List<GuiSlider> list_m_guiSlider;

        public override void Awake() {
            base.Awake();

            GameProgramManager.Instance().Set_GuiManager(this); //Override and Set Game Program GUIManager                        

            Init_GuiManager(this.transform, true);
        }

        //--GUI-PAGE-FUNCTION--
        public ENUMGuiPage Get_GuiPage_Current_Type() { return enum_pageCurrent; }
        public ENUMGuiPage Get_GuiPage_Previous_Type() { return enum_pagePrevious; }
        private void Set_GuiPage_Current(ENUMGuiPage _type) => enum_pageCurrent = _type; //PLEASE-USE-SETPAGE()
        private void Set_GuiPage_Previous(ENUMGuiPage _type) => enum_pagePrevious = _type; //PLEASE-USE-SETPAGE()
        public void SetPage(ENUMGuiPage _type) {
            if (Get_GuiPage_Current_Type() == _type)
                return;
            Set_GuiPage_Previous(Get_GuiPage_Current_Type());
            Set_GuiPage_Current(_type);
        }

        //--OTHERS--

        public void Reset_GuiManager() {

        }

        //GetComponents() is useless in this case, it didn't get and return inactive objects
        //Usage of RECURSIVE so BE CAREFUL
        public void Init_GuiManager(Transform targetTransform = null, bool isItself = false) {
            if (isItself)
                targetTransform = this.transform;
            if (targetTransform == null)
                return; //early-exit

            foreach (Transform item in targetTransform) {
                Process_GuiElement(item);
                if (item.childCount > 0)
                    Init_GuiManager(item, false); //WARNING-RECCURSIVE            
            }
        }

        /// <summary>
        /// Check whole gui element for components
        /// </summary>    
        private void Process_GuiElement(Transform _target) {
            GuiPage guiPage = _target.GetComponent<GuiPage>();
            if (guiPage != null) {
                list_m_guiPage.Add(guiPage);
            }

            GuiPopulate guiPopulate = _target.GetComponent<GuiPopulate>();
            if (guiPopulate != null) {
                list_m_guiPopulate.Add(guiPopulate);
                guiPopulate.Set_GuiManager(this);
                guiPopulate.Setup();
            }

            GuiElementObject guiObject = _target.GetComponent<GuiElementObject>();
            if (guiObject != null) {
                list_m_guiObject.Add(guiObject);
                guiObject.Set_GuiManager(this);
            }

            GuiText guiText = _target.GetComponent<GuiText>();
            if (guiText != null) {
                list_m_guiText.Add(guiText);
                guiText.Set_GuiManager(this);                
            }

            GuiButton guiButton = _target.GetComponent<GuiButton>();
            if (guiButton != null) {
                list_m_guiButton.Add(guiButton);
                guiButton.Set_GuiManager(this);
            }

            GuiSlider guiSlider = _target.GetComponent<GuiSlider>();
            if (guiSlider != null) {
                list_m_guiSlider.Add(guiSlider);
                guiSlider.SetGUIManager(this);
                guiSlider.Setup();
            }

            //Process Navigation Objects in each Navigation
        }

        private void SetupAllGUIElement() {
            //All gui element setup from their list
            //foreach (GUIPage guiPage in list_m_guiPage) 
            foreach (GuiElementObject obj in list_m_guiObject) {
                obj.Set_GuiManager(this);
            }

            foreach (GuiText text in list_m_guiText) {
                text.Set_GuiManager(this);                
            }

            foreach (GuiButton button in list_m_guiButton) {
                button.Set_GuiManager(this);
            }

            foreach (GuiSlider slider in list_m_guiSlider) {
                slider.SetGUIManager(this);
                slider.Setup();
            }
        }

        public List<GuiPage> GetAllPageOfType(ENUMGuiPage _type) {
            List<GuiPage> temp = new List<GuiPage>();
            foreach (GuiPage guiPage in list_m_guiPage) {
                if (guiPage.IsGuiPage(_type))
                    temp.Add(guiPage);
            }
            return temp; //return-result
        }

        public List<GuiElementObject> GetAllObjectOfType(ENUM_GUIELEMENT_OBJECT _type) {
            List<GuiElementObject> temp = new List<GuiElementObject>();
            foreach (GuiElementObject guiObject in list_m_guiObject) {
                if (guiObject.Is_GuiElementObject_Type(_type))
                    temp.Add(guiObject);
            }
            return temp; //return-result
        }

        public List<GuiText> GetAllTextOfType(ENUMGuiText _type) {
            List<GuiText> temp = new List<GuiText>();
            foreach (GuiText text in list_m_guiText) {
                
            }
            return temp; //return-result
        }

        public List<GuiButton> GetAllButtonOfType(ENUM_GUIELEMENT_BUTTON _type) {
            List<GuiButton> temp = new List<GuiButton>();
            foreach (GuiButton button in list_m_guiButton) {
                if (button.Is_GuiElementButton_Type(_type))
                    temp.Add(button);
            }
            return temp; //return-result
        }

        public List<GuiSlider> GetAllSliderOfType(ENUM_GUIELEMENT_SLIDER _type) {
            List<GuiSlider> temp = new List<GuiSlider>();
            foreach (GuiSlider slider in list_m_guiSlider) {
                if (slider.Is_GuiElementSlider_Type(_type))
                    temp.Add(slider);
            }
            return temp; //return-result
        }

        //--NAVIGATION--
        public void NavigateGUI(string _direction) {
            //up, down, left, right gui elements down
        }


        //--GUI-PAGE-FUNCTIONALITY--

        public void OpenGUIPage(ENUMGuiPage _type, bool _isCloseAllPage = true) {

            //Close all page, then open all specific pages
            if (_isCloseAllPage) {
                CloseGUIPageAll();
                OpenGUIPageSpecific(_type);
            }

            //If not want to close all page, but you want to close and open specific page
            //Please add all behavior here
            else {
                switch (_type) {
                    case ENUMGuiPage.K_MainMenu:
                        OpenGUIPageSpecific(ENUMGuiPage.K_MainMenu);
                        break;
                    case ENUMGuiPage.K_GameplayHud_Main:
                        OpenGUIPageSpecific(ENUMGuiPage.K_GameplayHud_Main);
                        break;
                    default:
                        break;
                }
            }
        }

        private void OpenGUIPageSpecific(ENUMGuiPage _type) {
            foreach (GuiPage guiPage in GetAllPageOfType(_type)) {
                guiPage.Set_Status_GuiPage_Active(true);
            }

            SetPage(_type);
        }

        public void CloseGUIPageAll() {
            foreach (GuiPage guiPage in list_m_guiPage) {
                guiPage.Set_Status_GuiPage_Active(false);
            }
        }

        public void CloseGUIPageSpecific(ENUMGuiPage _type) {
            foreach (GuiPage guiPage in GetAllPageOfType(_type)) {
                guiPage.Set_Status_GuiPage_Active(false);
            }
        }

        //--GUI-OBJECT-FUNCTIONALITY--

        public void UpdateGUIElementObject(ENUM_GUIELEMENT_OBJECT _type) {
            foreach (GuiElementObject _guiObject in GetAllObjectOfType(_type)) {
                switch (_type) {
                    case ENUM_GUIELEMENT_OBJECT.K_TIMER:
                        break;
                    case ENUM_GUIELEMENT_OBJECT.K_DISABLE_INPUT_INFO:
                        break;
                    default:
                        break;
                }
            }
        }

        //--GUI-TEXT-FUNCTIONALITY--

        public void Update_GuiElementText(ENUMGuiText _type) {
            List<GuiText> textList = GetAllTextOfType(_type);
            foreach (GuiText text in textList) {
                switch (_type) {
                    case ENUMGuiText.K_GameplayValue_Highscore:
                        text.Set_Text($"Highscore: {GameProgramManager.Instance().Get_GameValueManager().GetValue_CoinEarn()}");
                        break;
                    case ENUMGuiText.K_GameplayValue_TimeCountdown:
                        text.Set_Text($"Timer: {GameProgramManager.Instance().Get_TimeManager().Get_GameTimeCountdown()}");
                        break;
                    case ENUMGuiText.K_GameplayValue_Combo:
                        break;
                    case ENUMGuiText.K_GameplayValue_EnemyCount:
                        break;
                    default:
                        break;
                }
            }
        }

        //--GUI-BUTTON-FUNCTIONALITY--

        public void On_GuiElementButton(GuiButton _button, ENUM_GUIELEMENT_BUTTON _buttonType, ENUM_GUIELEMENT_POINTER _pointerStatus) {
            switch (_pointerStatus) {

                case ENUM_GUIELEMENT_POINTER.K_ON_ENTER:
                    //AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.HOVER);
                    break;

                case ENUM_GUIELEMENT_POINTER.K_ON_EXIT:
                    break;

                case ENUM_GUIELEMENT_POINTER.K_ON_HOVER:
                    break;

                case ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_DOWN:
                    //AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);

                    switch (_buttonType) {
                        case ENUM_GUIELEMENT_BUTTON.K_CLOSE:
                            break;

                        case ENUM_GUIELEMENT_BUTTON.K_NEXT:
                            switch (Get_GuiPage_Current_Type()) {
                                case ENUMGuiPage.K_TitleScreen:
                                    OpenGUIPage(ENUMGuiPage.K_MainMenu);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_BACK:

                            switch (Get_GuiPage_Previous_Type()) {
                                case ENUMGuiPage.K_Pause:
                                    OpenGUIPage(ENUMGuiPage.K_Pause);
                                    return;
                                default:
                                    break;
                            }

                            switch (Get_GuiPage_Current_Type()) {
                                case ENUMGuiPage.K_TitleScreen:
                                    OpenGUIPage(ENUMGuiPage.K_MainMenu);
                                    break;
                                case ENUMGuiPage.K_Option:
                                    switch (VLSceneTool.Get_Type_CurrentScene()) {
                                        case ENUM_SCENE.K_NONE:
                                            break;
                                        case ENUM_SCENE.K_SPLASH_SCREEN:
                                            break;
                                        case ENUM_SCENE.K_LOADING_SCREEN:
                                            break;
                                        case ENUM_SCENE.K_MAIN_MENU:
                                            OpenGUIPage(ENUMGuiPage.K_MainMenu);
                                            break;
                                        case ENUM_SCENE.K_GAMEPLAY:
                                            OpenGUIPage(ENUMGuiPage.K_GameplayHud_Main);
                                            break;
                                        case ENUM_SCENE.K_RESULT:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    OpenGUIPage(Get_GuiPage_Previous_Type());
                                    break;
                            }
                            break;

                        case ENUM_GUIELEMENT_BUTTON.K_LOADSCENE_MAINMENU:
                            VLSceneTool.Instance().Load_Async_Scene_Specific(ENUM_SCENE.K_MAIN_MENU);
                            break;

                        case ENUM_GUIELEMENT_BUTTON.K_LOADSCENE_GAMEPLAY:
                            VLSceneTool.Instance().Load_Async_Scene_Specific(ENUM_SCENE.K_GAMEPLAY);
                            break;

                        case ENUM_GUIELEMENT_BUTTON.K_FUNCTION_RESTART_GAME:
                            VLSceneTool.Load_CurrentScene_AutoBuildIndex();
                            break;

                        case ENUM_GUIELEMENT_BUTTON.K_FUNCTION_EXIT_TO_OS:
                            if (Application.platform != RuntimePlatform.WebGLPlayer)
                                Application.Quit();
                            break;

                        case ENUM_GUIELEMENT_BUTTON.K_GOTO_PAGE_OPTIONS:
                            OpenGUIPage(ENUMGuiPage.K_Option);
                            break;

                        case ENUM_GUIELEMENT_BUTTON.K_GOTO_PAGE_PAUSE:
                            OpenGUIPage(ENUMGuiPage.K_Pause);
                            break;

                        case ENUM_GUIELEMENT_BUTTON.K_FUNCTION_RESUME_GAME:
                            OpenGUIPage(ENUMGuiPage.K_GameplayHud_Main);
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_FUNCTION_PAUSE_GAME:
                            OpenGUIPage(ENUMGuiPage.K_Pause);
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_ASK_RESTART_GAME:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_ASK_EXIT_TO_MAINMENU:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_ASK_EXIT_TO_OS:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_GOTO_PAGE_LEADERBOARD:
                            OpenGUIPage(ENUMGuiPage.K_Leaderboard);
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_GOTO_PAGE_OPTIONS_DISPLAY:
                            OpenGUIPage(ENUMGuiPage.K_Option_Display);
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_GOTO_PAGE_OPTIONS_AUDIO:
                            OpenGUIPage(ENUMGuiPage.K_Option_Audio);
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_GOTO_PAGE_OPTIONS_LANGUAGE:
                            OpenGUIPage(ENUMGuiPage.K_Option_Localization);
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_FUNCTION_SET_LANGUAGE:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.NONE:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_ASK_RESET_SAVE_DATA:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_LOADSCENE_CURRENT:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_LOADSCENE_GAMEPLAY_RESULT:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_FUNCTION_RESET_SAVE_DATA:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_FUNCTION_SET_LANGUAGE_ENGLISH:
                            break;
                        case ENUM_GUIELEMENT_BUTTON.K_FUNCTION_SET_LANGUAGE_VIETNAMESE:
                            break;
                        default:
                            break;
                    }
                    break;

                case ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_HOLD:
                    break;

                case ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_RELEASE:
                    break;

                default:
                    break;
            }
        }        
    }
}


