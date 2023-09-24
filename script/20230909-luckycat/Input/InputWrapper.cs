using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLInput {    
    public class InputWrapper {        
        //--GAMEPROGRAM--
        public static void GameProgram_PauseResume() {
            //TODO - Check for ingame, not allow when main menu or something else
            GameProgramManager.Instance().Handle_PauseResume();
        }
        
        //--GUINAVIGATION--
        public static void GuiNavigation_MoveUp() {
            //Check for gameprogram allow gui input navigation
        }
        public static void GuiNavigation_MoveDown() {
            //Check for gameprogram allow gui input navigation
        }
        public static void GuiNavigation_MoveLeft() {
            //Check for gameprogram allow gui input navigation
        }
        public static void GuiNavigation_MoveRight() {
            //Check for gameprogram allow gui input navigation
        }
        public static void GuiNavigation_Confirm() {
            //Check for gameprogram allow gui input navigation
        }
        public static void GuiNavigation_Back() {
            //Check for gameprogram allow gui input navigation
        }

        //--MEMORYCARD--
        public static void MemoryCard_GameData_QuickSave() {
            //TODO - Check for allow quicksave
            Debug.Log("PLACEHOLDER PROTOTYPE - Quick Save");
        }
        public static void MemoryCard_GameData_QuickLoad() {
            //TODO - Check for allow quickload
            Debug.Log("PLACEHOLDER PROTOTYPE - Quick Load");
        }        
    }
}

