using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLGameComponent {
    public class GameComponentProjectile : MonoBehaviour {
        public void Play_ProjectileStart(ABSProjectile arg_projectile) {
            arg_projectile.Projectile_Start();
        }
        public void Play_ProjectileLoop(ABSProjectile arg_projectile) {
            arg_projectile.Projectile_Loop();
        }
        public void Play_ProjectileEnd(ABSProjectile arg_projectile) {
            arg_projectile.Projectile_End();
        }
    }
}
