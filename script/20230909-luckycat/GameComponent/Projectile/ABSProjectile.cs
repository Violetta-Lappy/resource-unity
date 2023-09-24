using UnityEngine;

namespace VLGameProject.VLGameComponent {
    public abstract class ABSProjectile : ScriptableObject {
        ProjectileData m_projectileData;
        public ProjectileData Get_ProjectileData() { return m_projectileData; }
        public abstract void Projectile_Start();
        public abstract void Projectile_Loop();
        public abstract void Projectile_End();
    }
}
