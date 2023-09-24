using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGameComponent {
    public class ComponentAbility : GameProgramObject {
        public ABSAbility m_currentAbility;
        public bool isActive;
        public bool isRechargeComplete;
        public bool isAllowAbility;

        public override void Update() {
            base.Update();
            if (isAllowAbility) {
                Play_AbilityLoop(m_currentAbility);
            }
            if (isRechargeComplete == false) {
                Play_AbilityRecharge(m_currentAbility);
            }
        }

        public void Play_AbilityStart(ABSAbility arg_ability) {
            if (isActive) {
                return;
            }
            isAllowAbility = true;
            isActive = true;
            arg_ability.Ability_Start();
        }
        public void Play_AbilityLoop(ABSAbility arg_ability) {
            if (isActive) {
                return;
            }
            arg_ability.Ability_Loop();
        }
        public void Play_AbilityEnd(ABSAbility arg_ability) {
            if (isActive) {
                return;
            }
            isAllowAbility = false;
            isActive = false;
            arg_ability.Ability_End();
        }
        public void Play_AbilityRecharge(ABSAbility arg_ability) => arg_ability.Ability_Recharge();
    }
}
