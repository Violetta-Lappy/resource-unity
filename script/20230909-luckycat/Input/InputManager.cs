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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UltEvents;
using UnityEngine;
using VLGameProject.Tool;

namespace VLGameProject.VLInput {

    public enum ENUM_INPUT_CONTEXT {
        K_NONE = 0,

        K_PROGRAM_PAUSERESUME_TOGGLE,
        //K_PROGRAM_PAUSERESUME_HOLD,

        K_PROGRAM_GUINAVIGATION_MOVEUP,
        K_PROGRAM_GUINAVIGATION_MOVEDOWN,
        K_PROGRAM_GUINAVIGATION_MOVELEFT,
        K_PROGRAM_GUINAVIGATION_MOVERIGHT,
        K_PROGRAM_GUINAVIGATION_CONFIRM,
        K_PROGRAM_GUINAVIGATION_BACK,

        K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKSAVE,
        K_PROGRAM_MEMORYCARD_GAMEDATA_QUICKLOAD,        

        //--GAME-GUI--
        K_GAME_GUI_PLAYEROVERVIEW,
        K_GAME_GUI_INVENTORY,
        K_GAME_GUI_JOURNAL,
        K_GAME_GUI_MAP,        

        //--PLAYER-MOVEMENT--
        K_GAME_PLAYER_MOVEUP,
        K_GAME_PLAYER_MOVEDOWN,
        K_GAME_PLAYER_MOVELEFT,
        K_GAME_PLAYER_MOVERIGHT,

        //--PLAYER-ACTION--
        K_GAME_PLAYER_ATTACK,
        K_GAME_PLAYER_DEFEND,
        K_GAME_PLAYER_FEVER,
        K_GAME_PLAYER_CROUCH,
        K_GAME_PLAYER_JUMP,
        K_GAME_PLAYER_INTERACT,
        K_GAME_PLAYER_RELOAD,
        K_GAME_PLAYER_SPECIAL,
    }

    public enum ENUM_INPUT_TYPE {
        K_PRESS,
        K_HOLD,
        K_RELEASE
    }

    public class InputManager : MonoBehaviour {

        [Header("InputManager-Event")]
        public UltEvent<ENUM_INPUT_CONTEXT> OnInputContextPress;
        public UltEvent<ENUM_INPUT_CONTEXT> OnInputContextHold;
        public UltEvent<ENUM_INPUT_CONTEXT> OnInputContextRelease;

        public UltEvent<ENUM_INPUT_CONTEXT> OnInputContextComboPress;
        public UltEvent<ENUM_INPUT_CONTEXT> OnInputContextComboHold;
        public UltEvent<ENUM_INPUT_CONTEXT> OnInputContextComboRelease;

        public UltEvent OnAnyKeyPress;
        public UltEvent OnAnyKeyRelease;

        [Header("InputManager-Variable")]
        public SOInputMap m_gameInputPreset;
        public SOInputMap Get_GameInputPreset() { return m_gameInputPreset; }
        public void Set_GameInputPreset(SOInputMap arg_gameInputPreset) => m_gameInputPreset = arg_gameInputPreset;

        //--VARIABLES--
        public Vector3 vec3_mousePos;
        public Vector3 vec3_touchPos;
        public bool isTouchClickTapOnce = false;

        public bool isAllowInput;
        public bool IsAllowInput() { return isAllowInput; }
        public void Set_IsAllowInput(bool arg_status) => isAllowInput = arg_status;

        public bool isEnableAnyKey = false;
        public bool IsEnableAnyKey() { return isEnableAnyKey; }
        public void Set_IsEnableAnyKey(bool arg_status) => isEnableAnyKey = arg_status;

        private KeyCode[] sz_m_allKeycode = (KeyCode[])Enum.GetValues(typeof(KeyCode));


        [Header("InputManager-InputContext")]
        public InputContext[] sz_m_inputContext;
        public InputContextCombo[] sz_m_inputContextCombo;
        public List<KeyCode> list_m_keyCodeActive = new List<KeyCode>(); //Check for active keycode has been press        

        private void Awake() {
            Set_IsAllowInput(true);
            Set_IsEnableAnyKey(true);

            if (Get_GameInputPreset() == null) {
                VLLogger.Warn($"No {nameof(SOInputMap)} ScriptableObject in {nameof(InputManager)}!! Switching to using class {nameof(SOInputMap)} version", this);
                //sz_m_inputContext = SOInputMap.Get_szInputContextReadOnly();
                //sz_m_inputContextCombo = SOInputMap.Get_szInputContextComboReadOnly();
            }
        }

        void Update() {
            UpdateMousePosition();

            if (isAllowInput == false)
                return; //early-exit        
            UpdateAnyKey();
            UpdateInputKeyboard();
            UpdateInputTouch();
        }

        //--INPUT-DISABLE--
        //USE WHEN NEEDED        
        public void DisableInputTemporary(float arg_disableTime = 3.0f) {
            StopCoroutine(Routine_DisableInputTemporary()); //Stop-stacking-on-this-Monobehavior
            StartCoroutine(Routine_DisableInputTemporary(arg_disableTime));
        }
        private IEnumerator Routine_DisableInputTemporary(float arg_disableTime = 3.0f) {
            isAllowInput = false;
            yield return new WaitForSeconds(arg_disableTime);
            isAllowInput = true;
        }

        //--EXTERNAL-USE--
        public bool Try_Get_ContextActive(ENUM_INPUT_CONTEXT _type, KeyCode[] _array) {
            foreach (KeyCode keyCode in _array)
                if (list_m_keyCodeActive.Contains(keyCode))
                    return true; //return-without-stacking
            return false; //return-default
        }

        public bool Try_Get_ContextPress(ENUM_INPUT_CONTEXT _type, KeyCode[] _array, out KeyCode _keyCode) {
            _keyCode = default;
            bool result = false;
            foreach (KeyCode keyCode in _array) {
                if (Input.GetKeyDown(keyCode)) {
                    _keyCode = keyCode;
                    result = true; //return-outcome
                }
            }
            return result; //return-default
        }
        public bool Try_Get_ContextHold(ENUM_INPUT_CONTEXT _type, KeyCode[] _array, out KeyCode _keyCode) {
            _keyCode = default;
            bool result = false;
            foreach (KeyCode keyCode in _array) {
                if (Input.GetKey(keyCode)) {
                    _keyCode = keyCode;
                    result = true;
                }
            }
            return result; //return-default
        }
        public bool Try_Get_ContextRelease(ENUM_INPUT_CONTEXT _type, KeyCode[] _array, out KeyCode _keyCode) {
            _keyCode = default;
            bool result = false;
            foreach (KeyCode keyCode in _array) {
                if (Input.GetKeyUp(keyCode)) {
                    _keyCode = keyCode;
                    result = true; //return-outcome
                }
            }
            return result; //return-default
        }

        public bool Try_Get_ContextComboPress(ENUM_INPUT_CONTEXT arg_type, KeyCode[] arg_szKeycode) {
            List<bool> satisfy = new List<bool>();
            satisfy.Clear();
            foreach (KeyCode keyCode in arg_szKeycode) {
                satisfy.Add(false);
            }

            for (int i = 0; i < arg_szKeycode.Length; i++) {
                foreach (KeyCode keyCodeActive in list_m_keyCodeActive) {
                    if (arg_szKeycode[i] == keyCodeActive) {
                        satisfy[i] = true;
                        continue;
                    }
                    else if (arg_szKeycode[i] != keyCodeActive) {
                        continue;
                    }
                }

                //Return when all condition satisfy
                if (satisfy.All(c => c == true)) {
                    return true; //return-result
                }
            }
            return false; //return-result
        }

        public bool IsContextKeyPress(ENUM_INPUT_CONTEXT _type) {
            return false;
        }

        //--OTHERS--

        public void UpdateAnyKey() {
            if (isEnableAnyKey == false)
                return;

            list_m_keyCodeActive.Clear(); //Clear every frame, ensure no dead key stuck

            //I hate you
            foreach (KeyCode keycode in sz_m_allKeycode) {
                if (Input.GetKeyDown(keycode)) {
                    //Debug.Log(keycode + " was pressed");
                    if (list_m_keyCodeActive.Contains(keycode) == false) {
                        list_m_keyCodeActive.Add(keycode);
                    }
                    OnAnyKeyPress?.Invoke();
                }

                if (Input.GetKey(keycode)) {
                    //Debug.Log(keycode + " was pressed");
                    if (list_m_keyCodeActive.Contains(keycode) == false) {
                        list_m_keyCodeActive.Add(keycode);
                    }
                    //OnAnyKeyPress?.Invoke();
                }

                if (Input.GetKeyUp(keycode)) {
                    //Debug.Log(keycode + " was release");
                    if (list_m_keyCodeActive.Contains(keycode)) {
                        list_m_keyCodeActive.Remove(keycode);
                    }
                    OnAnyKeyRelease?.Invoke();
                }
            }
        }

        public Vector3 GetMousePositionFromCamera() {
            Vector3 mousePos = GetMousePositionFromMonitor();
            mousePos.z = Camera.main.nearClipPlane;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }

        public Vector3 GetMousePositionFromMonitor() {
            UpdateMousePosition();
            return vec3_mousePos;
        }

        private void UpdateMousePosition() => vec3_mousePos = Input.mousePosition;
        private void UpdateTouchPos(Vector3 arg_value) => vec3_touchPos = arg_value;

        //DO-NOT-EDIT
        //TODO - PERFORMANCE CONCERN
        //TODO - FIX MULTIPLE KEY STACKING FUNCTION - only update per context per frame ony
        public void UpdateInputKeyboard() {
            KeyCode outKeyCode;

            //InputContext Loop
            foreach (InputContext hotkey in sz_m_inputContext) {
                if (Try_Get_ContextPress(hotkey.Get_TypeInputContext(), hotkey.Get_szKeycode(), out outKeyCode)) {
                    OnInputContextPress?.Invoke(hotkey.Get_TypeInputContext());
                }

                if (Try_Get_ContextHold(hotkey.Get_TypeInputContext(), hotkey.Get_szKeycode(), out outKeyCode)) {
                    OnInputContextHold?.Invoke(hotkey.Get_TypeInputContext());
                }

                if (Try_Get_ContextRelease(hotkey.Get_TypeInputContext(), hotkey.Get_szKeycode(), out outKeyCode)) {
                    OnInputContextRelease?.Invoke(hotkey.Get_TypeInputContext());
                }
            }

            //InputContextCombo Loop
            foreach (InputContextCombo combo in sz_m_inputContextCombo) {
                if (Try_Get_ContextComboPress(combo.Get_TypeInputContext(), combo.Get_szKeycode())) {

                    if (combo.IsCombinationPressOnce()) {
                        Debug.Log($"This {nameof(InputContextCombo)} has already press once, return back now");
                        return; //early-exit, hotkey must not press once
                    }

                    combo.Set_IsCombinationPressOnce(true);
                    OnInputContextComboPress?.Invoke(combo.Get_TypeInputContext());
                }

                if (Try_Get_ContextComboPress(combo.Get_TypeInputContext(), combo.Get_szKeycode())) {

                    if (combo.IsCombinationPressOnce() == false) {
                        Debug.Log($"This {nameof(InputContextCombo)} has already press once, return back now");
                        return; //early-exit, hotkey must not press once
                    }

                    combo.Set_IsCombinationPressOnce(false);
                    OnInputContextComboRelease?.Invoke(combo.Get_TypeInputContext());
                }
            }
        }

        //DO-NOT-EDIT
        //LIMIT TO ONE TOUCH
        public void UpdateInputTouch() {
            if (UnityEngine.Input.touchCount == 1) {

                UnityEngine.Touch touch = UnityEngine.Input.touches[0]; //Only get the touch from touches 0
                UpdateTouchPos(touch.position); //Get position from Touch, if detect one touch input

                switch (touch.phase) {
                    case TouchPhase.Began:
                        HandleTouchLogicClickTap();
                        break;
                    case TouchPhase.Stationary:
                        HandleTouchLogicHoldStationary();
                        break;
                    case TouchPhase.Ended:
                        HandleTouchLogicRelease();
                        break;
                    case TouchPhase.Moved:
                        break;
                    case TouchPhase.Canceled:
                        break;
                    default:
                        break;
                }
            }
        }

        //--TOUCH-HANDLE-LOGIC--
        //EDIT IF NEEDED
        public void HandleTouchLogicClickTap() {
            if (isTouchClickTapOnce == true)
                return; //early-exit
            isTouchClickTapOnce = true;
        }

        public void HandleTouchLogicHoldStationary() {
            //OnContextHold(ENUM_INPUT_CONTEXT.K_GAME_ATTACK); 
        }

        public void HandleTouchLogicRelease() {
            isTouchClickTapOnce = false;
            //OnContextRelease(ENUM_INPUT_CONTEXT.K_GAME_ATTACK);
        }
    }
}



