using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLAI {
    public abstract class SOABSGoap {
        public abstract void Goap_Init();
        public abstract void Goap_Start();
        public abstract void Goap_Loop();
        public abstract void Goap_End();
    }

    public class GoapManager : GameProgramObject {
        public SOABSGoap m_goapState;
        public SOABSGoap Get_GoapState() { return m_goapState; }

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

        private void Goap_Init() { }
        private void Goap_Start() { }
        private void Goap_Loop() { }
        private void Goap_End() { }
    }
}

