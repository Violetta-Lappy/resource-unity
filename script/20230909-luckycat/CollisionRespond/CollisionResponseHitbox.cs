using VLGameProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLCollisionRespond {
    [RequireComponent(typeof(CollisionResponseData))]
    public class CollisionResponseHitbox : MonoBehaviour {

        [SerializeField] private ENUM_HITBOX_TAG enum_ownerType;
        [SerializeField] private CollisionResponseData m_data;
        [SerializeField] private CollisionResponse m_collisionResponseParent;

        private void Start() {
            m_data = GetComponent<CollisionResponseData>();
            m_collisionResponseParent = m_data.Get_CollisionResponse_Parent();
        }
    }
}
