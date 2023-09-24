using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGui;

namespace VLGameProject.VLLocalization {
    public class LocalizationGuiElementText : MonoBehaviour {
        //This is use when there are GUIElementText Component
        //Change suitable font
        //Change text by getting the text from Localization Manager
        //Check what type of string context this is

        public GuiText m_guiElementText;

        private void OnEnable() {
            //Subscribe the event
        }

        private void OnDisable() {
            //Desubscribe the event
        }

        public void Set_Text() {

        }
    }
}
