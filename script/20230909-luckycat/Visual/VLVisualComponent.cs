using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLVisual {

    [System.Serializable]
    public class VLVisualSetting {        
        public bool isUpDown;
        public bool IsUpDown() { return isUpDown; }
        public VLVisualSetting Set_IsUpDown(bool arg_status) {
            isUpDown = arg_status;
            return this;
        }
        public float f_updownRate;
        public float Get_UpDownRate() { return f_updownRate; }
        public VLVisualSetting Set_UpDownRate(float arg_value) {
            f_updownRate = arg_value;
            return this;
        }
        public SOABSEase m_upDownEase;
        public bool isLeftRight;
        public float f_leftrightRate;
        public bool isFrontBack;
        public float f_frontbackRate;

        //Cursor Setting
        public bool isEnableOnClick;
        public bool isEnableOnHold;
        public bool isEnableOnMove;
        public bool isEnableOnRelease;
        public bool isEnableOnHover;        
    }

    public class VLVisualComponent : GameProgramObject {
        [Header("Visual-Variable")]
        public VLVisualSetting m_visualSetting;
        public VLVisualSetting Get_VisualSetting() { return m_visualSetting; }

        private void Reset() {
            Get_VisualSetting()
                .Set_IsUpDown(true)
                .Set_UpDownRate(10.0f);                
        }

        public override void Awake() {
            base.Awake();
        }
        public override void Start() {
            base.Start();
        }
        public override void Update() {
            base.Update();
        }
        public override void FixedUpdate() {
            base.FixedUpdate();
        }

        public void Visual_Trail() { }
        public void Visual_Impact() { }
        public void Visual_Popup() { }
    }
}
