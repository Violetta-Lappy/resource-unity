using UnityEngine;

namespace VLGameProject.VLCollisionRespond {
    public abstract class SOABSCollisionRespond : ScriptableObject {
        public abstract void OnCollisionRespondEnter(Collision arg_collision, Collider arg_collider);
        public abstract void OnCollisionRespondSchedule(Collision arg_collision, Collider arg_collider);
        public abstract void OnCollisionRespondStay(Collision arg_collision, Collider arg_collider);
        public abstract void OnCollisionRespondExit(Collision arg_collision, Collider arg_collider);
    }
}
