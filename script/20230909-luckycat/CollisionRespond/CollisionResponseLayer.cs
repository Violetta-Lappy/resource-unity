using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;
using VLGameProject.Tool;

namespace VLGameProject.VLCollisionRespond {
    [RequireComponent(typeof(CollisionResponseData))]
    public class CollisionResponseLayer : GameProgramObject {
        [SerializeField] private CollisionResponseData m_data;

        public override void Start() {
            base.Start();

            SetData(this.GetComponent<CollisionResponseData>());
        }

        public void SetData(CollisionResponseData _data) => m_data = _data;
        public CollisionResponseData GetData() { return m_data; }

        //--UNITY COLLISION TYPES--
        //DO NOT EDIT UNLESS NECCESSARY    

        private void OnCollisionEnter(Collision collision) {
            if (m_data.Is_Allow_OnCollideEnter()) {
                GetData().Set_Unity_Collision(collision);                
            }
        }

        private void OnCollisionStay(Collision collision) {
            if (m_data.Is_Allow_OnCollideStay()) {
                GetData().Set_Unity_Collision(collision);                
            }
        }

        private void OnCollisionExit(Collision collision) {
            if (m_data.Is_Allow_OnCollideExit()) {
                GetData().Set_Unity_Collision(collision);                
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (m_data.Is_Allow_OnOverlapEnter()) {
                GetData().Set_Unity_Collider(other);                
            }
        }

        private void OnTriggerStay(Collider other) {
            if (m_data.Is_Allow_OnOverlapStay()) {
                GetData().Set_Unity_Collider(other);                
            }
        }
        private void OnTriggerExit(Collider other) {
            if (m_data.Is_Allow_OnOverlapExit()) {
                GetData().Set_Unity_Collider(other);                
            }
        }
    }
}
