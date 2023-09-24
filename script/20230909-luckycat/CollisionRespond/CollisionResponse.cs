/*
Copyright 2023 hoanglongplanner 

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.

You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
using VLGameProject.VLGameProgram;
using VLGameProject.Tool;

namespace VLGameProject.VLCollisionRespond {
    public class CollisionResponse : GameProgramObject {

        [SerializeField] private RigidbodyPlayer m_physicsPlayer;

        public override void Awake() {
            base.Awake();

            //m_physicsPlayer = this.gameObject.IsNullAddComponent<RigidbodyPlayer>(this);
        }

        public bool IsActive() { return this.gameObject.activeSelf; }
        public void SetStatusActive(bool _status) => this.gameObject.SetActive(_status);

        //--CUSTOM COLLISION RESPOND--
        //ALLOW EDIT    

        public void OnCollideEnter(CollisionResponseData _a, CollisionResponseData _b) {
            if (_a.IsNullGenericStatus(this) || _b.IsNullGenericStatus(this))
                return; //safe-check, early-exit        

            var aType = _a.Get_CollisionResponse_Type();
            var bType = _b.Get_CollisionResponse_Type();
            var aHitboxOwnerType = _a.Get_HitboxTag_Type();
            var bHitboxOwnerType = _b.Get_HitboxTag_Type();

            //Play knockback first then                

            Debug.Log($"{this.gameObject.name} with collision contacts with {_a.Get_Unity_Collision().contacts[0].normal}");

            switch (aType) {
                case ENUM_COLLISION_RESPONSE.K_NONE:
                    break;
                case ENUM_COLLISION_RESPONSE.K_GENERIC:
                    break;
                case ENUM_COLLISION_RESPONSE.K_OBJECT:
                    break;
                case ENUM_COLLISION_RESPONSE.K_WALL:
                    break;
                case ENUM_COLLISION_RESPONSE.K_COLLECTIBLE:
                    break;
                case ENUM_COLLISION_RESPONSE.K_HITBOX:
                    switch (bType) {
                        case ENUM_COLLISION_RESPONSE.K_NONE:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_GENERIC:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_OBJECT:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_WALL:
                            _a.Get_Parent_GameObject().GetComponent<RigidbodyPlayer>().PlayVelocityKnockback(_a.Get_Unity_Collision().contacts[0].normal, 5.0f);
                            break;
                        case ENUM_COLLISION_RESPONSE.K_COLLECTIBLE:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_HITBOX:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_PLAYER:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_THREAT:
                            break;
                        default:
                            break;
                    }
                    break;
                case ENUM_COLLISION_RESPONSE.K_PLAYER:
                    switch (bType) {
                        case ENUM_COLLISION_RESPONSE.K_NONE:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_GENERIC:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_OBJECT:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_WALL:
                            _a.Get_Parent_GameObject().GetComponent<RigidbodyPlayer>().PlayVelocityKnockback(_a.Get_Unity_Collision().contacts[0].normal, 5.0f);
                            break;
                        case ENUM_COLLISION_RESPONSE.K_COLLECTIBLE:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_HITBOX:
                            _a.Get_Parent_GameObject().GetComponent<RigidbodyPlayer>().PlayVelocityKnockback(_a.Get_Unity_Collision().contacts[0].normal, 5.0f);
                            break;
                        case ENUM_COLLISION_RESPONSE.K_PLAYER:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_THREAT:
                            _a.Get_Parent_GameObject().GetComponent<RigidbodyPlayer>().PlayVelocityKnockback(_a.Get_Unity_Collision().contacts[0].normal, 5.0f);
                            break;
                        default:
                            break;
                    }
                    break;
                case ENUM_COLLISION_RESPONSE.K_THREAT:
                    switch (bType) {
                        case ENUM_COLLISION_RESPONSE.K_NONE:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_GENERIC:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_OBJECT:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_WALL:
                            _a.Get_Parent_GameObject().GetComponent<RigidbodyPlayer>().PlayVelocityKnockback(_a.Get_Unity_Collision().contacts[0].normal, 5.0f);
                            break;
                        case ENUM_COLLISION_RESPONSE.K_COLLECTIBLE:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_HITBOX:
                            _a.Get_Parent_GameObject().GetComponent<RigidbodyPlayer>().PlayVelocityKnockback(_a.Get_Unity_Collision().contacts[0].normal, 5.0f);
                            break;
                        case ENUM_COLLISION_RESPONSE.K_PLAYER:
                            break;
                        case ENUM_COLLISION_RESPONSE.K_THREAT:
                            _a.Get_Parent_GameObject().GetComponent<RigidbodyPlayer>().PlayVelocityKnockback(_a.Get_Unity_Collision().contacts[0].normal, 5.0f);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        public void OnCollideStay(CollisionResponseData _a, CollisionResponseData _b) {

        }

        public void OnCollideExit(CollisionResponseData _a, CollisionResponseData _b) {

        }

        public void OnOverlapEnter(CollisionResponseData _a, CollisionResponseData _b) {
            if (_a.IsNullGenericStatus(this) || _b.IsNullGenericStatus(this))
                return; //safe-check, early-exit

            ENUM_COLLISION_RESPONSE aType = _a.Get_CollisionResponse_Type();
            ENUM_COLLISION_RESPONSE bType = _b.Get_CollisionResponse_Type();
            ENUM_HITBOX_TAG aHitboxOwnerType = _a.Get_HitboxTag_Type();
            ENUM_HITBOX_TAG bHitboxOwnerType = _b.Get_HitboxTag_Type();

            switch (aType) {
                case ENUM_COLLISION_RESPONSE.K_GENERIC:
                    break;

                case ENUM_COLLISION_RESPONSE.K_OBJECT:
                    break;

                case ENUM_COLLISION_RESPONSE.K_COLLECTIBLE:
                    ComponentCollectible collectible = _a.Get_Parent_GameObject().IsNullGetComponent<ComponentCollectible>(this);
                    CollectibleData data = collectible.GetCollectibleData().IsNullGeneric(this);
                    switch (bType) {
                        case ENUM_COLLISION_RESPONSE.K_PLAYER:
                            data.SetTypeOwner(ENUM_COLLECT_OWNER.K_PLAYER);
                            break;
                        case ENUM_COLLISION_RESPONSE.K_THREAT:
                            data.SetTypeOwner(ENUM_COLLECT_OWNER.K_THREAT);
                            break;
                        default:
                            break;
                    }
                    collectible.Collect();
                    break;

                case ENUM_COLLISION_RESPONSE.K_HITBOX:
                    switch (aHitboxOwnerType) {
                        case ENUM_HITBOX_TAG.K_GENERIC:
                            //
                            break;
                        case ENUM_HITBOX_TAG.K_OBJECT:
                            break;
                        case ENUM_HITBOX_TAG.K_PLAYER:
                            switch (bType) {
                                case ENUM_COLLISION_RESPONSE.K_THREAT:
                                    //Cause damage and spin                                
                                    break;
                            }
                            break;
                        case ENUM_HITBOX_TAG.K_THREAT:
                            break;
                    }
                    break;

                case ENUM_COLLISION_RESPONSE.K_PLAYER:
                    switch (bType) {
                        case ENUM_COLLISION_RESPONSE.K_THREAT:
                            Debug.Log("Hello There, player touch threat");
                            break;
                        case ENUM_COLLISION_RESPONSE.K_COLLECTIBLE:
                            Debug.Log("Hello There, player touch collectible, destroy collectible");
                            break;
                        default:
                            break;
                    }
                    break;

                case ENUM_COLLISION_RESPONSE.K_THREAT:
                    break;

                default:
                    break;
            }
        }

        public void OnOverlapStay(CollisionResponseData _a, CollisionResponseData _b) {
            if (_a.IsNullGenericStatus(this) || _b.IsNullGenericStatus(this))
                return; //safe-check, early-exit
        }

        public void OnOverlapExit(CollisionResponseData _a, CollisionResponseData _b) {
            if (_a.IsNullGenericStatus(this) || _b.IsNullGenericStatus(this))
                return; //safe-check, early-exit
        }
    }
}
