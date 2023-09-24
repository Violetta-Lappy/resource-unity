using UnityEngine;
using VLGameProject.VLGameComponent;

namespace VLGameProject.VLGameComponent {
    public abstract class ABSAbility : ScriptableObject {
        public AbilityData m_abilityData;
        public bool isAllowInterrupt;
        public bool isRecharge;
        public abstract void Ability_Setup();
        public abstract void Ability_Reset();
        public abstract void Ability_Recharge();
        public abstract void Ability_Start();
        public abstract void Ability_Loop();
        public abstract void Ability_End();                
    }
}