using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
using DG.Tweening;

public class GUIManager : Singleton_Persist<GUIManager>
{
    [Header("OTHERS")]
    public GameObject popupPrefab;

    [Header("UI PAGES")]
    public GameObject[] uiPages;
    public GameObject[] uiRequestPages;
    public ENUM_UI_PAGES_ID currentPageID = ENUM_UI_PAGES_ID.MAIN_MENU;
    public ENUM_UI_PAGES_ID previousPageID = ENUM_UI_PAGES_ID.MAIN_MENU;
    public ENUM_UI_REQUEST_PAGE_ID requestPageID = ENUM_UI_REQUEST_PAGE_ID.NONE;

    [Header("GUIELEMENT MANAGER LISTS")]
    public List<CustomUIPopulate> cupList = new List<CustomUIPopulate>();
    public List<CustomUIText> cutList = new List<CustomUIText>();
    public List<CustomUIButton> cubList = new List<CustomUIButton>();
    public List<CustomUISlider> cusList = new List<CustomUISlider>();
    public List<CustomUIDropdown> cdcList = new List<CustomUIDropdown>();

    public Inventory modInventory, conInventory;
    public GameObject buyShopPage;

    public override void AwakeSingleton()
    {
        DebugSystem.Message("GUIManager init success !!", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.WARNING);
    }

    public void CheckGUIType(Transform targetTransform)
    {
        foreach (Transform guiChild in targetTransform)
        {
            CustomUIPopulate cupComponent = guiChild.GetComponent<CustomUIPopulate>();

            if (cupComponent != null)
            {
                //Add to the list, and skip to the next item
                cupList.Add(cupComponent);
                cupComponent.Setup();
                continue;
            }

            CustomUIText cutComponent = guiChild.GetComponent<CustomUIText>();

            if (cutComponent != null)
            {
                //Add to the list, and skip to the next item
                cutList.Add(cutComponent);
                cutComponent.Setup();
                continue;
            }

            CustomUIButton cubComponent = guiChild.GetComponent<CustomUIButton>();

            if (cubComponent != null)
            {
                //Add to the list, and skip to the next item
                cubList.Add(cubComponent);
                cubComponent.Setup();
                continue;
            }

            CustomUISlider cusComponent = guiChild.GetComponent<CustomUISlider>();

            if (cusComponent != null)
            {
                //Add to the list, and skip to the next item
                cusList.Add(cusComponent);
                cusComponent.Setup();
                continue;
            }

            CustomUIDropdown cdcComponent = guiChild.GetComponent<CustomUIDropdown>();

            if (cdcComponent != null)
            {
                //Add to the list, and skip to the next item
                cdcList.Add(cdcComponent);
                cdcComponent.Setup();
                continue;
            }
        }
    }

    //Recursive Pattern Coding
    public void InitGUISystem(Transform targetTransform = null, bool isItself = false)
    {
        if (isItself)
        {
            targetTransform = this.transform;
        }

        //Exit out if there is nothing
        if (targetTransform == null) return;

        foreach (Transform guiChild in targetTransform)
        {
            CheckGUIType(guiChild);

            if (guiChild.childCount > 0)
            {
                InitGUISystem(guiChild, false);
            }
        }
    }

    #region OPEN UI PAGE (NORMAL, REQUEST PAGE)

    public void OpenUIPage(ENUM_UI_PAGES_ID id,
    ENUM_UI_REQUEST_PAGE_ID id2 = ENUM_UI_REQUEST_PAGE_ID.NONE, bool isOpenRequestPage = false, bool isAllowSound = true)
    {
        //Get and set the previous page
        previousPageID = currentPageID;
        requestPageID = id2;

        //Reset all UI Page to false
        foreach (GameObject pageElement in uiPages)
        {
            pageElement.SetActive(false);
        }

        for (int i = 0; i < uiRequestPages.Length; i++)
        {
            uiRequestPages[i].SetActive(false);
        }

        //Doing something when situation needed      
        switch (id)
        {
            case ENUM_UI_PAGES_ID.MAIN_MENU:
                break;

            case ENUM_UI_PAGES_ID.GAMEPLAY_NORMAL:
                break;

            case ENUM_UI_PAGES_ID.PAUSE_GAME:
                break;

            case ENUM_UI_PAGES_ID.GAME_OVER:
                //In case of specific
                /*
                if (requestPageID == ENUM_UI_REQUEST_PAGE_ID.GAME_OVER_NONE_DRAW)
                {
                    OpenUIRequestPage(ENUM_UI_REQUEST_PAGE_ID.GAME_OVER_NONE_DRAW);
                }
                */

                OpenUIRequestPage(requestPageID, isAllowSound);
                break;

            //This handle all switching between comfirmation pages
            case ENUM_UI_PAGES_ID.ASK_CONFIRMATION:
                //In case of specific
                /*
                if (id2 == ENUM_UI_REQUEST_PAGE_ID.CONFIRMATION_GAME_SETUP)
                {
                    OpenUIRequestPage(ENUM_UI_REQUEST_PAGE_ID.CONFIRMATION_GAME_SETUP);
                }
                */

                OpenUIRequestPage(requestPageID, isAllowSound);
                break;

            default:
                break;
        }

        //Open specific UI Page, when not open any request page
        if (!isOpenRequestPage)
        {
            uiPages[(int)id - 1].SetActive(true);

            if (isAllowSound)
            {
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.UI_TRANSITION);
            }
        }

        //Set to the current page
        currentPageID = id;
    }

    private void OpenUIRequestPage(ENUM_UI_REQUEST_PAGE_ID uiRequestPage, bool isAllowSound = true)
    {
        uiRequestPages[(int)uiRequestPage - 1].SetActive(true);

        if (isAllowSound)
        {
            AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.WARNING_ALERT_REQUEST);
        }
    }

    //SHOULD OPTIMIZE THIS IN THE FUTURE
    //THIS IS BUGGY AND CONFUSING RIGHT NOW
    public void OpenUIPage_ViaPauseKey(bool isOpenPauseMenu = true)
    {
        if (MasterGameSystem.Instance.Get_CurrentSceneBuildID() != (int)ENUM_SCENE_NAME.MAIN_MENU)
        {
            if (isOpenPauseMenu)
            {
                //SHOULD NOT BE IN ANY REQUEST PAGE ID
                if (requestPageID == ENUM_UI_REQUEST_PAGE_ID.NONE)
                {
                    OpenUIPage(ENUM_UI_PAGES_ID.PAUSE_GAME, ENUM_UI_REQUEST_PAGE_ID.NONE, false, true);
                }
            }

            else if (!isOpenPauseMenu)
            {
                switch (MasterGameSystem.Instance.Get_CurrentSceneBuildID())
                {
                    case (int)ENUM_SCENE_NAME.GAMEPLAY:
                        OpenUIPage(ENUM_UI_PAGES_ID.GAMEPLAY_NORMAL);
                        break;

                    default:
                        break;
                }
            }
        }
    }

    public void OpenUIShopPage_ViaBuyKey(bool status = false)
    {
        buyShopPage.SetActive(status);
    }

    #endregion **OPEN UI PAGE (NORMAL, REQUEST PAGE)**

    #region --TEXT MANAGER--    
    public CustomUIText Get_SpecificText(ENUM_UI_TEXT_TYPE textType)
    {
        CustomUIText temp = cutList[0];

        for (int i = 0; i < cutList.Count; i++)
        {
            if (cutList[i].textType == textType)
            {
                temp = cutList[i];
            }
        }

        return temp;
    }

    public void UpdateText(ENUM_UI_TEXT_TYPE textType, string text = "")
    {
        CustomUIText cut = Get_SpecificText(textType);

        cut.SetText(text);

        //Special Cases
        switch (textType)
        {
            case ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_MASTER:
                cut.SetText("Master Vol: " + SaveDataMNG.Load_OptionsMixerMaster());
                break;

            case ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_MUSIC:
                cut.SetText("Music Vol: " + SaveDataMNG.Load_OptionsMixerMusic());
                break;

            case ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_SFX:
                cut.SetText("SFX Vol: " + SaveDataMNG.Load_OptionsMixerSFX());
                break;

            case ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_SFX_UI:
                cut.SetText("SFX UI Vol: " + SaveDataMNG.Load_OptionsMixerSFX_UI());
                break;

            case ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_SFX_CAR:
                cut.SetText("SFX Car Vol: " + SaveDataMNG.Load_OptionsMixerSFX_Game());
                break;

            case ENUM_UI_TEXT_TYPE.CURRENCY_COIN:
                cut.SetText(SaveDataMNG.Load_GameCurrency().ToString());
                break;
        }
    }


    #endregion __TEXT MANAGER__

    #region --BUTTONS MANAGER--    

    public void UIButtonManager(CustomUIButton cub, ENUM_UI_BUTTON_TYPE bType, ENUM_UI_ELEMENTS_STATUS uiEleStatus)
    {
        switch (uiEleStatus)
        {
            case ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONCE:
                //Play sound upon click
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);

                if (bType == ENUM_UI_BUTTON_TYPE.GO_TO_NEXT_PAGE)
                {

                }

                if (bType == ENUM_UI_BUTTON_TYPE.BACK_PAGE)
                {
                    //If currently in How To Play, Go back to Main Menu
                    if (currentPageID == ENUM_UI_PAGES_ID.HOW_TO_PLAY)
                    {
                        OpenUIPage(ENUM_UI_PAGES_ID.MAIN_MENU);
                    }

                    else if (currentPageID == ENUM_UI_PAGES_ID.OPTIONS)
                    {
                        //Check if the previous in Mainmenu Mode
                        if (previousPageID == ENUM_UI_PAGES_ID.MAIN_MENU)
                        {
                            OpenUIPage(ENUM_UI_PAGES_ID.MAIN_MENU);
                        }

                        //CHeck if the previous in Gameplay Mode - Pause Game or not                        
                        else if (previousPageID == ENUM_UI_PAGES_ID.PAUSE_GAME)
                        {
                            OpenUIPage(ENUM_UI_PAGES_ID.PAUSE_GAME);
                        }
                    }

                    else if (currentPageID == ENUM_UI_PAGES_ID.CREDIT_SCREEN)
                    {
                        OpenUIPage(ENUM_UI_PAGES_ID.MAIN_MENU);
                    }

                    //From Request Page, back to
                    else if (currentPageID == ENUM_UI_PAGES_ID.ASK_CONFIRMATION)
                    {
                        if (requestPageID == ENUM_UI_REQUEST_PAGE_ID.CONFIRMATION_RETRY)
                        {
                            OpenUIPage(ENUM_UI_PAGES_ID.PAUSE_GAME);
                        }

                        else if (requestPageID == ENUM_UI_REQUEST_PAGE_ID.CONFIRMATION_QUIT_TO_MAIN_MENU)
                        {
                            OpenUIPage(ENUM_UI_PAGES_ID.PAUSE_GAME);
                        }

                        else if (requestPageID == ENUM_UI_REQUEST_PAGE_ID.CONFIRMATION_QUIT_TO_OS)
                        {
                            //Back to Pause Menu
                            if (previousPageID == ENUM_UI_PAGES_ID.MAIN_MENU)
                            {
                                OpenUIPage(ENUM_UI_PAGES_ID.MAIN_MENU);
                            }

                            //Back to Pause Menu
                            else if (previousPageID == ENUM_UI_PAGES_ID.PAUSE_GAME)
                            {
                                OpenUIPage(ENUM_UI_PAGES_ID.PAUSE_GAME);
                            }
                        }
                    }
                }

                if (bType == ENUM_UI_BUTTON_TYPE.CLOSE_PAGE)
                {
                    this.gameObject.transform.parent.gameObject.SetActive(false);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.GOTO_PAGE_HOW_TO_PLAY)
                {
                    OpenUIPage(ENUM_UI_PAGES_ID.HOW_TO_PLAY);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.GOTO_PAGE_OPTIONS)
                {
                    OpenUIPage(ENUM_UI_PAGES_ID.OPTIONS);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.GOTO_PAGE_CREDIT)
                {
                    OpenUIPage(ENUM_UI_PAGES_ID.CREDIT_SCREEN);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.GOTO_LEVEL_GAMEPLAY)
                {
                    MasterGameSystem.Instance.Load_SpecificScene(ENUM_SCENE_NAME.GAMEPLAY);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.GOTO_LEVEL_TUTORIAL)
                {
                    MasterGameSystem.Instance.Load_SpecificScene(ENUM_SCENE_NAME.TUTORIAL);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.FUNCTION_RESUME)
                {
                    MasterGameSystem.Instance.SysResume();

                    OpenUIPage(ENUM_UI_PAGES_ID.GAMEPLAY_NORMAL);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.FUNCTION_PAUSE_GAME)
                {
                    MasterGameSystem.Instance.SysPause();

                    OpenUIPage(ENUM_UI_PAGES_ID.PAUSE_GAME);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.SHOP_ITEM)
                {
                    CustomUIValues tempCUV = cub.Get_CustomUIValue();

                    switch (tempCUV.Get_IntValue1stIndex())
                    {
                        case (int)ENUM_SHOP_ITEM_TYPE.HEALTH_POTION:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {

                                Debug.Log(InventoryManager.Instance.GetItem("healthPosition"));
                                conInventory.AddItem(InventoryManager.Instance.GetItem("healthPosition"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }

                            break;

                        case (int)ENUM_SHOP_ITEM_TYPE.MANA_POTION:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {
                                conInventory.AddItem(InventoryManager.Instance.GetItem("manaPosition"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }

                            break;
                    }
                }

                /*
                if (bType == ENUM_UI_BUTTON_TYPE.SHOP_SKILL_ITEM)
                {
                    CustomUIValues tempCUV = cub.Get_CustomUIValue();

                    switch (tempCUV.Get_IntValue1stIndex())
                    {
                        case (int)ENUM_SHOP_SKILL_ITEM_TYPE.DASH:
                            DebugSystem.Message("Hello " + tempCUV.Get_IntValue1stIndex() + " from: " + cub.transform.parent.name,
                    ENUM_DEBUG_CATALOG.GAMEPLAY_SCENE, ENUM_DEBUG_TYPE.NORMAL);
                            break;

                        case (int)ENUM_SHOP_SKILL_ITEM_TYPE.INVUL:
                            DebugSystem.Message("Hello " + tempCUV.Get_IntValue1stIndex() + " from: " + cub.transform.parent.name,
                    ENUM_DEBUG_CATALOG.GAMEPLAY_SCENE, ENUM_DEBUG_TYPE.NORMAL);
                            break;

                        case (int)ENUM_SHOP_SKILL_ITEM_TYPE.TIME_STOP:
                            DebugSystem.Message("Hello " + tempCUV.Get_IntValue1stIndex() + " from: " + cub.transform.parent.name,
                    ENUM_DEBUG_CATALOG.GAMEPLAY_SCENE, ENUM_DEBUG_TYPE.NORMAL);
                            break;
                    }
                }

                if (bType == ENUM_UI_BUTTON_TYPE.SHOP_UPGRADE_ITEM)
                {
                    CustomUIValues tempCUV = cub.Get_CustomUIValue();

                    switch (tempCUV.Get_IntValue1stIndex())
                    {
                        case (int)ENUM_SHOP_UPGRADE_ITEM_TYPE.ATK:
                            DebugSystem.Message("Hello " + tempCUV.Get_IntValue1stIndex() + " from: " + cub.transform.parent.name,
                    ENUM_DEBUG_CATALOG.GAMEPLAY_SCENE, ENUM_DEBUG_TYPE.NORMAL);
                            break;

                        case (int)ENUM_SHOP_UPGRADE_ITEM_TYPE.DEF:
                            DebugSystem.Message("Hello " + tempCUV.Get_IntValue1stIndex() + " from: " + cub.transform.parent.name,
                    ENUM_DEBUG_CATALOG.GAMEPLAY_SCENE, ENUM_DEBUG_TYPE.NORMAL);
                            break;

                        case (int)ENUM_SHOP_UPGRADE_ITEM_TYPE.SPD:
                            DebugSystem.Message("Hello " + tempCUV.Get_IntValue1stIndex() + " from: " + cub.transform.parent.name,
                    ENUM_DEBUG_CATALOG.GAMEPLAY_SCENE, ENUM_DEBUG_TYPE.NORMAL);
                            break;
                    }
                } 
                 */


                if (bType == ENUM_UI_BUTTON_TYPE.SHOP_ATTACH_ITEM)
                {
                    CustomUIValues tempCUV = cub.Get_CustomUIValue();

                    switch (tempCUV.Get_IntValue1stIndex())
                    {
                        case (int)ENUM_SHOP_ATTACHMENT_ITEM_TYPE.SHOTGUN:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {
                                modInventory.AddItem(InventoryManager.Instance.GetItem("shotgun"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }
                            break;
                        
                        /*
                        case (int)ENUM_SHOP_ATTACHMENT_ITEM_TYPE.AUTO_SHOTGUN:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {
                                modInventory.AddItem(InventoryManager.Instance.GetItem("autoshotgun"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }
                            break;                          
                         */

                        case (int)ENUM_SHOP_ATTACHMENT_ITEM_TYPE.SPEED:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {
                                modInventory.AddItem(InventoryManager.Instance.GetItem("speed"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }
                            break;

                        case (int)ENUM_SHOP_ATTACHMENT_ITEM_TYPE.FIRE:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {
                                modInventory.AddItem(InventoryManager.Instance.GetItem("fire"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }
                            break;

                        case (int)ENUM_SHOP_ATTACHMENT_ITEM_TYPE.WATER:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {
                                modInventory.AddItem(InventoryManager.Instance.GetItem("water"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }
                            break;

                        case (int)ENUM_SHOP_ATTACHMENT_ITEM_TYPE.ELECTRIC:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {
                                modInventory.AddItem(InventoryManager.Instance.GetItem("electric"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }
                            break;

                        case (int)ENUM_SHOP_ATTACHMENT_ITEM_TYPE.POISON:
                            if (CurrencyManager.Instance.CompareCurrency(10, ENUM_CURRENCY_TYPE.COIN_MONEY))
                            {
                                modInventory.AddItem(InventoryManager.Instance.GetItem("poison"));

                                CurrencyManager.Instance.DecreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 10);
                            }
                            break;

                    }

                    //Debug.Log(tempCUV.Get_IntValue1stIndex());
                }

                #region CONFIRMATIONS BUTTONS

                if (bType == ENUM_UI_BUTTON_TYPE.ASK_QUIT_TO_MAIN_MENU)
                {
                    OpenUIPage(ENUM_UI_PAGES_ID.ASK_CONFIRMATION, ENUM_UI_REQUEST_PAGE_ID.CONFIRMATION_QUIT_TO_MAIN_MENU, true);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.FUNCTION_QUIT_TO_MAIN_MENU)
                {
                    MasterGameSystem.Instance.Load_SpecificScene(ENUM_SCENE_NAME.MAIN_MENU);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.ASK_QUIT_TO_OS)
                {
                    OpenUIPage(ENUM_UI_PAGES_ID.ASK_CONFIRMATION, ENUM_UI_REQUEST_PAGE_ID.CONFIRMATION_QUIT_TO_OS, true);
                }

                if (bType == ENUM_UI_BUTTON_TYPE.FUNCTION_QUIT_TO_OS)
                {
                    MasterGameSystem.Instance.SysQuit();
                }

                if (bType == ENUM_UI_BUTTON_TYPE.FUNCTION_RESET_SAVE_DATA)
                {
                    SaveDataMNG.ResetSaveData();
                }

                if (bType == ENUM_UI_BUTTON_TYPE.FUNCTION_RESTART_GAME)
                {
                    MasterGameSystem.Instance.Load_CurrentScene_AutoBuildIndex();
                }

                #endregion __CONFIRMATION BUTTONS__

                break;

            case ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONGOING:
                //DO NOT USE THIS
                break;

            case ENUM_UI_ELEMENTS_STATUS.MOUSE_RELEASE:
                //DO NOT USE THIS
                break;

            case ENUM_UI_ELEMENTS_STATUS.ENTER:
                //USE THIS
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.HOVER);

                if (bType == ENUM_UI_BUTTON_TYPE.GO_TO_NEXT_PAGE)
                {
                    cub.transform.DOScale(new Vector2(1.1f, 1.1f), 0.25f);
                }
                break;

            case ENUM_UI_ELEMENTS_STATUS.HOVER_UPDATE:
                //DO NOT USE THIS
                break;

            case ENUM_UI_ELEMENTS_STATUS.EXIT:
                //DO NOT USE THIS

                if (bType == ENUM_UI_BUTTON_TYPE.GO_TO_NEXT_PAGE)
                {
                    cub.transform.DOScale(new Vector2(1, 1), 0.25f);
                }
                break;
        }
    }

    #endregion --BUTTONS MANAGER--

    #region --SLIDER MANAGER--
    public CustomUISlider Get_SpecificSlider(ENUM_UI_SLIDER_TYPE sliderType)
    {
        CustomUISlider tempCUS = null;

        foreach (CustomUISlider cus in cusList)
        {
            if (cus.sliderType == sliderType)
            {
                tempCUS = cus;
            }
        }

        return tempCUS;
    }

    public void UISliderButtonManager(ENUM_UI_ELEMENTS_STATUS uiEleStats)
    {
        switch (uiEleStats)
        {
            case ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONCE:
                //Play audio here
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);

                //USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONGOING:
                //DO NOT USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.MOUSE_RELEASE:
                //DO NOT USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.ENTER:
                //Play audio here
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.HOVER);

                //USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.HOVER_UPDATE:
                //DO NOT USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.EXIT:
                //DO NOT USE THIS                
                break;

            default:
                break;
        }
    }

    public void SliderCreatorManager(ENUM_UI_SLIDER_TYPE uiSliderType, CustomUISlider cus = null, bool allowAutoFind = false)
    {
        if (allowAutoFind)
        {
            cus = Get_SpecificSlider(uiSliderType);
        }

        switch (uiSliderType)
        {
            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_MASTER:
                cus.SetupSlider(ProjectConstants.AUDIO_SLIDER_MIN, ProjectConstants.AUDIO_SLIDER_MAX, SaveDataMNG.Load_OptionsMixerMaster());

                SliderOnValueChangeManager(ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_MASTER, null, true);
                break;

            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_MUSIC:
                cus.SetupSlider(ProjectConstants.AUDIO_SLIDER_MIN, ProjectConstants.AUDIO_SLIDER_MAX, SaveDataMNG.Load_OptionsMixerMusic());

                SliderOnValueChangeManager(ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_MUSIC, null, true);
                break;

            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX:
                cus.SetupSlider(ProjectConstants.AUDIO_SLIDER_MIN, ProjectConstants.AUDIO_SLIDER_MAX, SaveDataMNG.Load_OptionsMixerSFX());

                SliderOnValueChangeManager(ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX, null, true);
                break;

            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX_UI:
                cus.SetupSlider(ProjectConstants.AUDIO_SLIDER_MIN, ProjectConstants.AUDIO_SLIDER_MAX, SaveDataMNG.Load_OptionsMixerSFX_UI());

                SliderOnValueChangeManager(ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX_UI, null, true);
                break;

            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX_CAR:
                cus.SetupSlider(ProjectConstants.AUDIO_SLIDER_MIN, ProjectConstants.AUDIO_SLIDER_MAX, SaveDataMNG.Load_OptionsMixerSFX_Game());

                SliderOnValueChangeManager(ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX_CAR, null, true);
                break;

            default:
                break;
        }
    }

    //Execute all functions when slider changes it value, to reflect necessary protocol realtime
    public void SliderOnValueChangeManager(ENUM_UI_SLIDER_TYPE uiSliderType, CustomUISlider cus = null, bool allowAutoFind = false)
    {
        if (allowAutoFind)
        {
            cus = Get_SpecificSlider(uiSliderType);
        }

        switch (uiSliderType)
        {
            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_MASTER:
                SaveDataMNG.Save_OptionsMixerMaster(cus.Get_SliderValue());

                AudioManager.Instance.SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_MasterVol);

                UpdateText(ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_MASTER);
                break;

            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_MUSIC:
                SaveDataMNG.Save_OptionsMixerMusic(cus.Get_SliderValue());

                AudioManager.Instance.SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_MusicVol);

                UpdateText(ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_MUSIC);
                break;

            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX:
                SaveDataMNG.Save_OptionsMixerSFX(cus.Get_SliderValue());

                AudioManager.Instance.SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFXVol);

                UpdateText(ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_SFX);
                break;

            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX_UI:
                SaveDataMNG.Save_OptionsMixerSFX_UI(cus.Get_SliderValue());

                AudioManager.Instance.SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_UIVol);

                UpdateText(ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_SFX_UI);
                break;

            case ENUM_UI_SLIDER_TYPE.OPTIONS_MIXER_SFX_CAR:
                SaveDataMNG.Save_OptionsMixerSFX_GAME(cus.Get_SliderValue());

                AudioManager.Instance.SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_GameVol);

                UpdateText(ENUM_UI_TEXT_TYPE.OPTIONS_MIXER_SFX_CAR);
                break;

            default:
                break;
        }
    }
    #endregion __SLIDER MANAGER__

    #region --DROPDOWN_MANAGER--
    public CustomUIDropdown Get_SpecificDropdown(ENUM_DROPDOWN_TYPE dropdownType)
    {
        CustomUIDropdown tempCUD = null;

        foreach (CustomUIDropdown cud in cdcList)
        {
            if (cud.dropdownType == dropdownType)
            {
                tempCUD = cud;
            }
        }

        return tempCUD;
    }

    //Allow the use of what happen to dropdown when mouse click, enter, hover, exit it
    public void DropdownButtonManager(ENUM_UI_ELEMENTS_STATUS uiEleStats)
    {
        switch (uiEleStats)
        {
            case ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONCE:
                //Play audio here
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);

                //USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONGOING:
                //DO NOT USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.MOUSE_RELEASE:
                //DO NOT USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.ENTER:
                //Play audio here
                AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.HOVER);

                //USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.HOVER_UPDATE:
                //DO NOT USE THIS                
                break;

            case ENUM_UI_ELEMENTS_STATUS.EXIT:
                //DO NOT USE THIS                
                break;

            default:
                break;
        }
    }

    public void SetupDropdownOptionsList(CustomUIDropdown cdc, DatabaseMain database)
    {
        switch (cdc.dropdownType)
        {
            case ENUM_DROPDOWN_TYPE.OPTIONS_SCREEN_RESOLUTIONS:
                for (int i = 0; i < ProjectConstants.screen_Widths.Count; i++)
                {
                    cdc.Add_DropdownOptions(ProjectConstants.screen_Widths[i] + " x " + ProjectConstants.screen_Heights[i]);
                }
                break;

            default:
                break;
        }
    }

    //What happen when selected an item inside the dropdown
    public void DropdownItemSelected(CustomUIDropdown cdc, bool allowPlayAudio = true)
    {
        switch (cdc.dropdownType)
        {
            case ENUM_DROPDOWN_TYPE.OPTIONS_SCREEN_RESOLUTIONS:

                //Set that resolution after make a choice
                SaveDataMNG.Save_OptionsMonitorType(cdc.Get_SelectedItemValue());

                //Set the resolution
                SaveDataMNG.Load_OptionsMonitorType();
                break;

            default:
                break;
        }

        if (allowPlayAudio)
        {
            AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);
        }
    }
    #endregion --DROPDOWN MANAGER--

    #region POPULATE MANAGER
    //Spawn stuff in UI when needed
    public void PopulateUIMaker(ENUM_UI_POPULATE_TYPE populateType, CustomUIPopulate cup, GameObject uiPrefab)
    {
        switch (populateType)
        {
            case ENUM_UI_POPULATE_TYPE.NONE:

                for (int i = 0; i < 10; i++)
                {
                    GameObject newUIPrefab = Instantiate(uiPrefab, this.transform);
                    CustomUIValues cuv = newUIPrefab.GetComponent<CustomUIValues>();

                    //cuv.SetID(0, 0);
                    //cuv.SetSprite(,0)
                    //cuv.SetText("example", 0);
                }

                break;

            case ENUM_UI_POPULATE_TYPE.EXAMPLE:
                break;

            case ENUM_UI_POPULATE_TYPE.SHOP_ITEM:

                for (int i = 0; i < MasterGameSystem.Instance.databaseMain.shopItemDB.Length; i++)
                {
                    ShopItem currentShopItem = MasterGameSystem.Instance.databaseMain.shopItemDB[i];

                    //Make new gameObject at the parent
                    GameObject newUIPrefab = Instantiate(uiPrefab, cup.transform);

                    //Add the values to the one
                    CustomUIValues cuv = newUIPrefab.GetComponent<CustomUIValues>();
                    cuv.Setup1stIndex(i, 0, currentShopItem.icon, currentShopItem.itemName);

                    newUIPrefab.SetActive(true);
                }
                break;

            case ENUM_UI_POPULATE_TYPE.SHOP_UPGRADE:

                for (int i = 0; i < MasterGameSystem.Instance.databaseMain.shopUpgradeDB.Length; i++)
                {
                    ShopUpgradeItem currentShopUpgradeItem = MasterGameSystem.Instance.databaseMain.shopUpgradeDB[i];

                    //Make new gameObject at the parent
                    GameObject newUIPrefab = Instantiate(uiPrefab, cup.transform);

                    //Add the values to the one
                    CustomUIValues cuv = newUIPrefab.GetComponent<CustomUIValues>();
                    cuv.Setup1stIndex(i, 0, currentShopUpgradeItem.icon, currentShopUpgradeItem.upgradeName);

                    newUIPrefab.SetActive(true);
                }
                break;

            case ENUM_UI_POPULATE_TYPE.SHOP_SKILLS:

                for (int i = 0; i < MasterGameSystem.Instance.databaseMain.shopSkillDB.Length; i++)
                {
                    ShopSkillItem currentShopSkillItem = MasterGameSystem.Instance.databaseMain.shopSkillDB[i];

                    //Make new gameObject at the parent
                    GameObject newUIPrefab = Instantiate(uiPrefab, cup.transform);

                    //Add the values to the one
                    CustomUIValues cuv = newUIPrefab.GetComponent<CustomUIValues>();
                    cuv.Setup1stIndex(i, 0, currentShopSkillItem.icon, currentShopSkillItem.skillName);

                    newUIPrefab.SetActive(true);
                }
                break;

            case ENUM_UI_POPULATE_TYPE.SHOP_ATTACHMENT:

                for (int i = 0; i < MasterGameSystem.Instance.databaseMain.shopAttachDB.Length; i++)
                {
                    ShopAttachItem currentShopAttachItem = MasterGameSystem.Instance.databaseMain.shopAttachDB[i];

                    //Make new gameObject at the parent
                    GameObject newUIPrefab = Instantiate(uiPrefab, cup.transform);

                    //Add the values to the one
                    CustomUIValues cuv = newUIPrefab.GetComponent<CustomUIValues>();
                    cuv.Setup1stIndex(i, 0, currentShopAttachItem.icon, currentShopAttachItem.attachmentName);

                    newUIPrefab.SetActive(true);
                }
                break;

            default:
                break;
        }
    }

    #endregion --POPULATE MANAGER--

    #region OTHER FUNCTIONS
    public void Create_WorldPopUp(Vector3 pos, string text, Color color)
    {
        CustomWorldPopup cwp = Instantiate(popupPrefab, pos, Quaternion.identity).GetComponent<CustomWorldPopup>();

        if (cwp == null)
        {
            DebugSystem.Message("This is not an object with CustomWorldPopup component !!", ENUM_DEBUG_CATALOG.GAMEPLAY_MANAGER, ENUM_DEBUG_TYPE.ERROR);
            return;
        }

        cwp.Setup(text, color);

        cwp.gameObject.SetActive(true);
    }

    #endregion __OTHER FUNCTIONS__
}
