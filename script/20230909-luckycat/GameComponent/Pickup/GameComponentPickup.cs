using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGameComponent {
    public class GameComponentPickup : GameProgramObject {
        public SOABSPickup m_pickup;
        public SOABSPickup Get_Pickup() { return m_pickup; }
        public void Set_Pickup(SOABSPickup arg_pickup) {
            Get_Pickup().Pickup_Terminate();

            m_pickup = arg_pickup;
            Get_Pickup().Pickup_Init();
        }

        public override void Start() {
            base.Start();
        }

        public override void Update() {
            base.Update();
            if (Get_Pickup().Get_PickupSetting().IsTimeLimit()) {
                                
                float timelimit = Get_Pickup().Get_PickupSetting().Get_TimeLimit();

                if (timelimit < 0) {
                    GameComponentPickup_Fail();
                    return;
                }

                timelimit--;
            }            
        }

        public void GameComponentPickup_Success() => Get_Pickup().OnPickupSuccess?.Invoke();
        public void GameComponentPickup_Fail() => Get_Pickup().OnPickupFail?.Invoke();        
    }
}
