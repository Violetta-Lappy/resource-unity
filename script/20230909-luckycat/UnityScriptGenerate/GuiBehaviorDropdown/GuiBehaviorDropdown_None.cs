using UnityEngine;
namespace VLGameProject.VLGui {
    [CreateAssetMenu(fileName = "New None", menuName = "VLGameProject/GuiDropdownBehavior/New None")]
    public class GuiDropdownBehavior_None : SOABSGuiDropdownBehavior {

        public static readonly string[] sz_str_string = new string[] {
            "24",
            "30",
            "36",
            "48",
            "60",
            "72",
            "75",
            "90",
            "120",
            "144",
            "165",
            "240",
            "360",
            "480",
        };

        public static string[] Get_szString() {
            return sz_str_string;
        }

        public override void GuiDropdownBehavior_EditorReset(GuiDropdown arg_dropdown) {
            if (arg_dropdown != null) {
                arg_dropdown.Dropdown_Clear(); //must-clear-list-first
                foreach (string str in Get_szString()) {
                    arg_dropdown.Dropdown_Add_Item(str);
                }
            }
        }

        public override void GuiDropdownBehavior_Init() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnDropdownItemSelect() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnMouseDown() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnMouseDrag() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnMouseHold() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnMouseMove() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnMouseRelease() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnMouseWheel() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnPointerEnter() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnPointerExit() {
            throw new System.NotImplementedException();
        }

        public override void GuiDropdownBehavior_OnPointerHover() {
            throw new System.NotImplementedException();
        }
    }
}

