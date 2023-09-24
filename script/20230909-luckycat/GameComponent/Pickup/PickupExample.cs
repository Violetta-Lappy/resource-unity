using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLGameComponent {
    [CreateAssetMenu(fileName = "New Pickup-Example", menuName = "VLGameProject/Pickup/New Pickup-Example")]
    public class PickupExample : SOABSPickup {       
        private void Reset() {
            Get_PickupSetting()
                .Set_IsTimeLimit(true)
                .Set_TimeLimit(300.0f);
        }

        public override void Pickup_Init() {
            base.Pickup_Init();
        }

        public override void Pickup_Terminate() {
            base.Pickup_Terminate();
        }

        public override void Pickup_OnPickupSuccess() {

        }

        public override void Pickup_OnPickupFail() {

        }
    }
}
