using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGameComponent {
    public class GameComponentWeapon : GameProgramObject {
        public ABSWeapon m_currentWeapon;
        public bool isActive;
        public bool isRechargeComplete;
        public bool isAllowAbility;

        public override void Update() {
            base.Update();
            if (isAllowAbility) {
                Play_WeaponLoop(m_currentWeapon);
            }
            if (isRechargeComplete == false) {
                Play_WeaponRecharge(m_currentWeapon);
            }
        }

        public void Play_WeaponStart(ABSWeapon arg_weapon) {
            if (isActive) {
                return;
            }
            isAllowAbility = true;
            isActive = true;
            arg_weapon.Weapon_Start();
        }
        public void Play_WeaponLoop(ABSWeapon arg_weapon) {
            if (isActive) {
                return;
            }
            arg_weapon.Weapon_Loop();
        }
        public void Play_WeaponEnd(ABSWeapon arg_weapon) {
            if (isActive) {
                return;
            }
            isAllowAbility = false;
            isActive = false;
            arg_weapon.Weapon_End();
        }
        public void Play_WeaponRecharge(ABSWeapon arg_weapon) => arg_weapon.Weapon_Reload();
    }
}
