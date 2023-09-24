using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    bool detect;

    private void Update()
    {
        if (detect)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                //GUIManager.Instance.SetActive_ShopGUI(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(ProjectConstants.TAG_PLAYER))
        {
            Debug.Log("In the shop !! Press E to open it !!");
            detect = true;
        }        
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag(ProjectConstants.TAG_PLAYER))
        {
            //GUIManager.Instance.SetActive_ShopGUI(false);
            detect = false;
        }
    }    
}
