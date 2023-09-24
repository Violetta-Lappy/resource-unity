using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLAI {
    public class FsmManager : GameProgramObject {

        public ABSFsmState m_currentFsmState;
        public ABSFsmState Get_CurrentFsmState() { return m_currentFsmState; }

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

        public void FSM_Init() { }
        public void FSM_Start() { }
        public void FSM_Loop() { }
        public void FSM_End() { }
    }
}

