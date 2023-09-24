using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLAI {
    public class BehaviorTreeManager : GameProgramObject {

        ABSBehaviorTreeNode m_behaviorTreeNode;
        
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

        public void BehaviorTree_Init() { }
        public void BehaviorTree_Start() { }
        public void BehaviorTree_Loop() { }
        public void BehaviorTree_End() { }
    }
}
