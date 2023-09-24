using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VLGameProject.VLGui {
    public class GuiDropdown : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
        [Header("GuiManager")]
        public GuiManager m_guiManager;
        public void Set_GuiManager(GuiManager _guiManager) => m_guiManager = _guiManager;
        
        [Header("GuiBehavior")]
        public SOABSGuiDropdownBehavior m_guiBehaviorDropdown;
        public SOABSGuiDropdownBehavior Get_GuiBehaviorDropdown() { return m_guiBehaviorDropdown; }

        [Header("Dropdown")]
        public TMP_Dropdown m_dropdown;
        public bool isMouseHover = false;        

        [ContextMenu("VL_EditorReset")]
        private void VL_EditorReset() {
            m_dropdown = this.GetComponent<TMP_Dropdown>();
            Get_GuiBehaviorDropdown()?.GuiDropdownBehavior_EditorReset(this);
        }

        public void Setup() {
            //CreateDropdown(MasterGameSystem.Instance.databaseMain);
        }

        private void Awake() { 
            //Null-Check
        }

        private void Update() {
            if (isMouseHover && GuiSetting.K_EnablePointerOnMouseHover) {
                //m_guiManager.DropdownButtonManager(ENUM_GUIELEMENT_POINTER.K_ON_HOVER);
            }
        }

        public int Get_Value_Selected_Item() { return m_dropdown.value; }

        //Detect if a click occurs
        public void OnPointerClick(PointerEventData eventData) {
            if (GuiSetting.K_EnablePointerOnMouseDown) {
                //m_guiManager.DropdownButtonManager(ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_DOWN);
            }
        }

        //Detect current clicks on the GameObject (the one with the script attached)    
        public void OnPointerDown(PointerEventData pointerEventData) {
            if (GuiSetting.K_EnablePointerOnMouseHold) {
                //m_guiManager.DropdownButtonManager(ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_HOLD);
            }
        }

        //Detect if clicks are no longer registering
        public void OnPointerUp(PointerEventData pointerEventData) {
            if (GuiSetting.K_EnablePointerOnMouseRelease) {
                //m_guiManager.DropdownButtonManager(ENUM_GUIELEMENT_POINTER.K_ON_MOUSE_RELEASE);
            }
        }

        //Detect if the Cursor starts to pass over the GameObject
        public void OnPointerEnter(PointerEventData eventData) {
            //Mouse hover detected
            isMouseHover = true;

            if (GuiSetting.K_EnablePointerOnMouseEnter) {
                //m_guiManager.DropdownButtonManager(ENUM_GUIELEMENT_POINTER.K_ON_ENTER);
            }
        }

        //Detect when Cursor leaves the GameObject
        public void OnPointerExit(PointerEventData eventData) {
            //Disable mouse hover function
            isMouseHover = false;

            if (GuiSetting.K_EnablePointerOnMouseExit) {
                //m_guiManager.DropdownButtonManager(ENUM_GUIELEMENT_POINTER.K_ON_EXIT);
            }
        }

        //public void CreateDropdown(DatabaseMain mainDatabase) {        
        //    m_dropdown.options.Clear();

        //    GUIManager.Instance.SetupDropdownOptionsList(this, mainDatabase);

        //    //Initialize the first item and reset variable
        //    GUIManager.Instance.DropdownItemSelected(this, false);

        //    //Listen for the Dropdown change by Player
        //    m_dropdown.onValueChanged.AddListener(delegate { m_guiManager.DropdownOnItemSelected(this); });

        //    m_dropdown.RefreshShownValue();
        //}

        public void Dropdown_Clear() => m_dropdown.options.Clear();
        public void Dropdown_Add_Item(string _text) => m_dropdown.options.Add(new TMP_Dropdown.OptionData(_text));
    }
}
