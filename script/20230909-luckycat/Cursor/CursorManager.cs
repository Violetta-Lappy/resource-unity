using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLCursor {
    public class CursorManager : GameProgramObject {
        public enum ENUM_CURSOR_TYPE {
            K_CLICK_INTEREST,
            K_QUESTION,
            K_NOT_ALLOW
        }

        public CursorPreset m_cursorPreset;

        public override void Start() {
            base.Start();
        }

        public override void Update() {
            base.Update();
        }

        public void Set_CursorSprite(ENUM_CURSOR_TYPE _type) {
            switch (_type) {
                case ENUM_CURSOR_TYPE.K_CLICK_INTEREST:
                    break;
                case ENUM_CURSOR_TYPE.K_NOT_ALLOW:
                    break;
                case ENUM_CURSOR_TYPE.K_QUESTION:
                    break;
                default:
                    break;
            }
        }

        public void Set_CursorVisible(bool _status) => Cursor.visible = _status;
        public void Set_CursorLockState(CursorLockMode _type) => Cursor.lockState = _type;
    }
}

