using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLAI;

namespace VLGameProject.VLAI {
    public abstract class ABSFsmState {
        public abstract void FsmState_Init(FsmManager arg_fsmManager);
        public abstract void FsmState_Start(FsmManager arg_fsmManager);
        public abstract void FsmState_Loop(FsmManager arg_fsmManager);
        public abstract void FsmState_End(FsmManager arg_fsmManager);
    }
}

