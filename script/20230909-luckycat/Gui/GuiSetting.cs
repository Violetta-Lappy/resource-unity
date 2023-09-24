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

namespace VLGameProject.VLGui {
    [System.Serializable]
    public class GuiSetting {
        public static bool K_EnablePointerOnMouseEnter = true; //def: true    
        public static bool K_EnablePointerOnMouseHover = false; //def: false
        public static bool K_EnablePointerOnMouseExit = true; //def: true
        public static bool K_EnablePointerOnMouseDown = true; //def: true
        public static bool K_EnablePointerOnMouseHold = false; //def: false
        public static bool K_EnablePointerOnMouseRelease = false; //def: false                                                               
    }
}


