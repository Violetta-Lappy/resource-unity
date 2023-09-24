/*
Copyright 2023 hoanglongplanner 

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

using UnityEngine;

namespace VLGameProject.VLInput {
    /// <summary>
    /// Input Context for combination of per key
    /// </summary>
    [System.Serializable]
    public class InputContext {
        public ENUM_INPUT_CONTEXT enum_contextType;
        public KeyCode[] sz_m_keycode;

        public InputContext(ENUM_INPUT_CONTEXT arg_contextType, KeyCode[] arg_keyCode) {
            enum_contextType = arg_contextType;
            sz_m_keycode = arg_keyCode;
        }

        public ENUM_INPUT_CONTEXT Get_TypeInputContext() { return enum_contextType; }
        public KeyCode[] Get_szKeycode() { return sz_m_keycode; }
    }
}



