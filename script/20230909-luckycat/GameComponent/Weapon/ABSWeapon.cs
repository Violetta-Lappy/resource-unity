using UnityEngine;

namespace VLGameProject.VLGameComponent {
    public abstract class ABSWeapon : ScriptableObject {
        public WeaponData m_weaponData;
        public WeaponData Get_WeaponData() { return m_weaponData; }
        public abstract void Weapon_Start();
        public abstract void Weapon_Loop();
        public abstract void Weapon_End();
        public abstract void Weapon_Reload();
    }
}

