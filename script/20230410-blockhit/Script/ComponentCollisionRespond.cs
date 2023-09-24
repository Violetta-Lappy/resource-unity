using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ComponentTag), typeof(Rigidbody))]
public class ComponentCollisionRespond : MonoBehaviour {
    ComponentTag m_componentTag;

    private void Start() => m_componentTag = this.GetComponent<ComponentTag>();

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ComponentTag>() == null) return; //safe-check-early-exit
        OnCollisionRespondEnter(other.gameObject, m_componentTag.GetTagType(), other.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<ComponentTag>() == null) return; //safe-check-early-exit
        OnCollisionRespondStay(other.gameObject, m_componentTag.GetTagType(), other.GetComponent<ComponentTag>().GetTagType()); 
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<ComponentTag>() == null) return; //safe-check-early-exit
        OnCollisionRespondExit(other.gameObject, m_componentTag.GetTagType(), other.GetComponent<ComponentTag>().GetTagType()); 
    }

    private void OnCollisionRespondEnter(GameObject _gameObject, ENUM_TAG_TYPE _thisType, ENUM_TAG_TYPE _compareTag) {
        switch (_thisType) {
            case ENUM_TAG_TYPE.PLAYER_HUB:
                switch (_compareTag) {
                    case ENUM_TAG_TYPE.OBSTACLE:
                        //APIHelperVioletRoot.ToolLog.Debug("Obstacle being hit by player", this);
                        ComponentObstacle temp = _gameObject.GetComponent<ComponentObstacle>();
                        if (temp.IsPaint() == false) {
                            temp.SetObstacleStatus(true); //obstacle-being-painted                    
                            ManagerGameValue.Instance.IncreaseFever(1.0f);
                        }                                                            
                        break;
                    default: return; //safe-check-early-exit                                        
                }
                break;
            case ENUM_TAG_TYPE.ENEMY:
                switch (_compareTag) {
                    case ENUM_TAG_TYPE.OBSTACLE:
                        //APIHelperVioletRoot.ToolLog.Debug("Obstacle being hit by enemy", this);
                        ComponentObstacle temp = _gameObject.GetComponent<ComponentObstacle>();
                        if (temp.IsPaint()) temp.SetObstacleStatus(false); //obstacle-being-painted
                        break;
                    default: return; //safe-check-early-exit                                        
                }
                break;
            case ENUM_TAG_TYPE.OBSTACLE: return; //safe-check-early-exit                
            case ENUM_TAG_TYPE.PLATFORM: break;
            case ENUM_TAG_TYPE.GROUND_CHECK: break;
            default: return; //safe-check-early-exit                
        }
    }

    private void OnCollisionRespondStay(GameObject _gameObject, ENUM_TAG_TYPE _thisType, ENUM_TAG_TYPE _compareTag) {
        switch (_thisType) {
            case ENUM_TAG_TYPE.GROUND_CHECK:
                switch (_compareTag) {
                    case ENUM_TAG_TYPE.PLATFORM: 
                        ControllerPlayer.Instance.SetSafeStatus(true);
                        ControllerPlayer.Instance.SetPossibleControllerParentToPlatform(_gameObject.transform);                                                
                        break;
                    default: return; //safe-check-early-exit                                        
                }
                break;
            default: return; //safe-check-early-exit                
        }
    }

    private void OnCollisionRespondExit(GameObject _gameObject, ENUM_TAG_TYPE _thisType, ENUM_TAG_TYPE _compareTag) {
        switch (_thisType) {
            case ENUM_TAG_TYPE.GROUND_CHECK:
                switch (_compareTag) {
                    case ENUM_TAG_TYPE.PLATFORM: 
                        ControllerPlayer.Instance.SetSafeStatus(false);
                        ControllerPlayer.Instance.SetPossibleControllerParentToPlatform(null);
                        break;
                    default: return; //safe-check-early-exit                                        
                }
                break;
            default: return; //safe-check-early-exit                
        }
    }
}
