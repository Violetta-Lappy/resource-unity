using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLAI;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLAI {
    public abstract class ABSAiDirector : GameProgramObject {

        public override void Awake() {
            base.Awake();
            AiDirector_Awake();
        }

        public override void Start() {
            base.Start();
            AiDirector_Start();
        }

        public override void Update() {
            base.Update();
            AiDirector_Update();
        }

        public abstract void AiDirector_Awake();
        public abstract void AiDirector_Start();
        public abstract void AiDirector_Update();
    }
}

