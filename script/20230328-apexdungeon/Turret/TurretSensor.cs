using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSensor : MonoBehaviour
{
    public Turret turret;    

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(ProjectConstants.TAG_PLAYER))
        {
            turret.ActivateGun(other.gameObject.transform);            
        }        
    }    

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag(ProjectConstants.TAG_PLAYER))
        {
            turret.DeactivateFireGun();
        }           
    }
}
