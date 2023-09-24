using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLAI;

namespace VLGameProject.VLAI {
    public abstract class ABSBehaviorTreeNode {
        public abstract void BTNode_Init(BehaviorTreeManager arg_behaviorTreeManager);
        public abstract void BTNode_Start(BehaviorTreeManager arg_behaviorTreeManager);
        public abstract void BTNode_Loop(BehaviorTreeManager arg_behaviorTreeManager);
        public abstract void BTNode_End(BehaviorTreeManager arg_behaviorTreeManager);
    }
}

