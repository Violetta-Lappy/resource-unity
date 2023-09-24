using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentCollisionResponse : MonoBehaviour
{
    ComponentTag m_componentTag;

    private void Start()
    {
        m_componentTag = this.GetComponent<ComponentTag>();
    }        

    private void OnCollisionEnter(Collision collision) {
        OnCollisionRespond(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTag());
        Debug.Log("Detect something");
    }
    private void OnTriggerEnter(Collider other) {
        OnCollisionRespond(other.gameObject, other.gameObject.GetComponent<ComponentTag>().GetTag());
        Debug.Log("Detect something trigger");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //OnCollisionRespond(hit.gameObject, hit.gameObject.GetComponent<ComponentTag>().GetTag());        
    }          

    public void OnCollisionRespond(GameObject collisionObject, ENUM_OBJECT_TAG collisionTag)
    {
        ENUM_OBJECT_TAG currentTag = m_componentTag.GetTag();

        switch(currentTag)
        {
            case ENUM_OBJECT_TAG.PLAYER:
                if (collisionTag == ENUM_OBJECT_TAG.GROUND) { this.GetComponent<ComponentMovement>().SetIsGrounded(true); }
                if (collisionTag == ENUM_OBJECT_TAG.OBSTACLE) { ManagerGame.Instance.EventGameOver(); }
                break;

            case ENUM_OBJECT_TAG.GROUND: break;
            case ENUM_OBJECT_TAG.OBSTACLE: break;
        }
    }
}
