using VLGameProject.Tool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLCollisionRespond {        
    public enum ENUM_COLLISION_RESPONSE {
        K_NONE = 0,
        K_GENERIC = 10, //Everything will be hurt
        K_OBJECT = 20,
        K_WALL = 21,
        K_COLLECTIBLE = 30,
        K_HITBOX = 40, //Multiple Hitbox
        K_PLAYER = 50,
        K_THREAT = 60,
    }

    public enum ENUM_HITBOX_TAG {
        K_NONE = 0,
        K_GENERIC = 10, //Everything will be hurt
        K_OBJECT = 20,
        K_PLAYER = 30,
        K_THREAT = 40,

        //TODO Character Hitbox (Head, Arm, Body, Leg, Hand, Foot)
        //K_CHARACTER_HEAD = 500,
        //K_CHARACTER_BODY,
        //K_CHARACTER_LEG,
        //K_CHARACTER_ARM,
        //K_CHARACTER_HAND,
        //K_CHARACTER_TAIL,
        //K_CHARACTER_FOOT,
    }

    [System.Serializable]
    public class CollisionResponseData {

        [Header("Feature")]
        public bool isAllowOnOverlapEnter = true; //def: true
        public bool isAllowOnOverlapStay = false; //def: false
        public bool isAllowOnOverlapExit = true; //def: true
        public bool isAllowOnCollideEnter = true; //def: true
        public bool isAllowOnCollideStay = false; //def: false
        public bool isAllowOnCollideExit = true; //def: true

        public bool Is_Allow_OnCollideEnter() { return isAllowOnCollideEnter; }
        public bool Is_Allow_OnCollideStay() { return isAllowOnCollideStay; }
        public bool Is_Allow_OnCollideExit() { return isAllowOnCollideExit; }
        public bool Is_Allow_OnOverlapEnter() { return isAllowOnOverlapEnter; }
        public bool Is_Allow_OnOverlapStay() { return isAllowOnOverlapStay; }
        public bool Is_Allow_OnOverlapExit() { return isAllowOnOverlapExit; }

        public float f_scheduleTime;
        public float Get_ScheduleTime() { return f_scheduleTime; }        

        [Header("Data")]
        [SerializeField] private CollisionResponse m_parent;
        [SerializeField] private CollisionResponseLayer m_layer;
        [SerializeField] private ENUM_COLLISION_RESPONSE enum_type;

        [Header("Data Hitbox")]
        [SerializeField] private ENUM_HITBOX_TAG enum_hitboxTagType;

        [Header("Collision Data")]
        [SerializeField] private Collider m_unityCollider;
        [SerializeField] private Collision m_unityCollision;

        //--FEATURES--            

        //--EXTENSIONS--    

        public GameObject Get_Parent_GameObject() { return m_parent.gameObject; }
        public GameObject Get_Layer_GameObject() { return m_layer.gameObject; }

        public void Set_CollisionResponse_Parent(CollisionResponse _parent) => m_parent = _parent;
        public CollisionResponse Get_CollisionResponse_Parent() { return m_parent; }

        public void Set_CollisionResponse_Layer(CollisionResponseLayer _layer) => m_layer = _layer;
        public CollisionResponseLayer Get_CollisionResponse_Layer() { return m_layer; }

        public ENUM_COLLISION_RESPONSE Get_CollisionResponse_Type() { return enum_type; }
        public bool Is_CollisionResponse_Type(ENUM_COLLISION_RESPONSE _type) { return enum_type == _type; }

        public ENUM_HITBOX_TAG Get_HitboxTag_Type() { return enum_hitboxTagType; }
        public bool Is_HitboxTag_Type(ENUM_HITBOX_TAG _type) { return enum_hitboxTagType == _type; }
        public void Set_HitboxTag_Type(ENUM_HITBOX_TAG _type) => enum_hitboxTagType = _type;

        //Unity Collision Info
        public void Set_Unity_Collision(Collision _collision) => m_unityCollision = _collision;
        public Collision Get_Unity_Collision() { return m_unityCollision; }

        //Unity Collider Info
        public void Set_Unity_Collider(Collider _collider) => m_unityCollider = _collider;
        public Collider Get_Unity_Collider() { return m_unityCollider; }
    }
}
