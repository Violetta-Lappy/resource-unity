using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

namespace VLGameProject.VLLocalization {
    public class LocalizationManager : MonoBehaviour {
        //TODO
        //Load csv file
        //Check what type language currently have, allow switching
        //Get string that check type
        //https://www.andiamo.co.uk/resources/iso-language-codes/

        //Only use general language that is not specific to each country
        //Save a lot of headache thinking other things                        

        [Header("Signal")]
        public UltEvent OnLanguageChange;

        [Header("LocalizationFile")]
        public SOLocalization m_english;
        public SOLocalization m_vietnamese;
        public SOLocalization m_german;

        private void Awake() {
            //Bind to event            
        }

        public string Get_LocalizationText(ENUMLocalizationLanguage arg_languageType, ENUMLocalizationContext arg_contextType) {
            return "";
        }        
    }
}
