using UltEvents;
using UnityEngine;

namespace VLGameProject.VLGameComponent {
    public abstract class SOABSPickup : ScriptableObject {
        [Header("Pickup-Behavior")]
        public UltEvent OnPickupSuccess;
        public UltEvent OnPickupFail;
        [Header("Pickup-Variable")]
        public PickupSetting m_pickupSetting;
        public PickupSetting Get_PickupSetting() { return m_pickupSetting; }
        public PickupData m_pickupData;
        public PickupData Get_PickupData() { return m_pickupData; }     
        
        public virtual void Pickup_Init() {
            OnPickupSuccess += Pickup_OnPickupSuccess;
            OnPickupFail += Pickup_OnPickupFail;
        }

        public virtual void Pickup_Terminate() {
            OnPickupSuccess -= Pickup_OnPickupSuccess;
            OnPickupFail -= Pickup_OnPickupFail;
        }

        public abstract void Pickup_OnPickupSuccess();
        public abstract void Pickup_OnPickupFail();
    }
}
