using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLCollisionRespond;

namespace VLGameProject.VLCollisionRespond {
    public class CollisionResponseComponent : MonoBehaviour {
        public CollisionResponseData m_collisionResponseData;
        public CollisionResponseData Get_CollisionResponseData() { return m_collisionResponseData; }
        public SOABSCollisionRespond m_collisionRespond;
        public SOABSCollisionRespond Get_CollisionRespond() { return m_collisionRespond; }

        private void Reset() {

        }

        private void Update() {

        }

        private void OnCollisionEnter(Collision collision) => Get_CollisionRespond()?.OnCollisionRespondEnter(collision, null);
        private void OnCollisionStay(Collision collision) => Get_CollisionRespond()?.OnCollisionRespondStay(collision, null);
        private void OnCollisionExit(Collision collision) => Get_CollisionRespond()?.OnCollisionRespondExit(collision, null);
        private void OnTriggerEnter(Collider other) => Get_CollisionRespond()?.OnCollisionRespondEnter(null, other);
        private void OnTriggerStay(Collider other) => Get_CollisionRespond()?.OnCollisionRespondStay(null, other);
        private void OnTriggerExit(Collider other) => Get_CollisionRespond()?.OnCollisionRespondExit(null, other);
    }
}
