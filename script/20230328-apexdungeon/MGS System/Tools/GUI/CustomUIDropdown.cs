using UnityEngine;

//Added library
using UnityEngine.EventSystems;
using TMPro;

//Stick this to everywhere you want
[RequireComponent(typeof(TMP_Dropdown))]
public class CustomUIDropdown : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ENUM_DROPDOWN_TYPE dropdownType = ENUM_DROPDOWN_TYPE.EXAMPLE;
    public TMP_Dropdown sampleDropdown;
    private bool isMouseHover = false;    

    public void Setup()
    {
        sampleDropdown = this.GetComponent<TMP_Dropdown>();

        CreateDropdown(MasterGameSystem.Instance.databaseMain);
    }

    private void Update()
    {
        if (isMouseHover)
        {
            if (ProjectConstants.ENABLE_SYSFUNCTION_UI_HOVER_UPDATE)
                GUIManager.Instance.DropdownButtonManager(ENUM_UI_ELEMENTS_STATUS.HOVER_UPDATE);
        }
    }

    public int Get_SelectedItemValue()
    {
        return sampleDropdown.value;                
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData eventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_MOUSE_CLICK_ONCE)
            GUIManager.Instance.DropdownButtonManager(ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONCE);
    }

    //Detect current clicks on the GameObject (the one with the script attached)    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_MOUSE_CLICK_ONGOING)
            GUIManager.Instance.DropdownButtonManager(ENUM_UI_ELEMENTS_STATUS.MOUSE_CLICKS_ONGOING);
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_RELEASE)
            GUIManager.Instance.DropdownButtonManager(ENUM_UI_ELEMENTS_STATUS.MOUSE_RELEASE);
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Mouse hover detected
        isMouseHover = true;

        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_ENTER)
            GUIManager.Instance.DropdownButtonManager(ENUM_UI_ELEMENTS_STATUS.ENTER);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
        //Disable mouse hover function
        isMouseHover = false;

        if (ProjectConstants.ENABLE_SYSFUNCTION_UI_EXIT)
            GUIManager.Instance.DropdownButtonManager(ENUM_UI_ELEMENTS_STATUS.EXIT);
    }

    public void CreateDropdown(DatabaseMain mainDatabase)
    {
        //Clear carDropdown list
        sampleDropdown.options.Clear();

        GUIManager.Instance.SetupDropdownOptionsList(this, mainDatabase);        

        //Initialize the first item and reset variable
        GUIManager.Instance.DropdownItemSelected(this, false);

        //Listen for the Dropdown change by Player
        sampleDropdown.onValueChanged.AddListener(delegate { GUIManager.Instance.DropdownItemSelected(this); });

        sampleDropdown.RefreshShownValue();        
    }

    public void Add_DropdownOptions(string optionTexts)
    {
        sampleDropdown.options.Add(new TMP_Dropdown.OptionData(optionTexts));
    }    
}
