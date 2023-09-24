using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObstacleSensor : MonoBehaviour
{
    public PlatformObstacle platformObstacle;    

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(ProjectConstants.TAG_PLAYER))
        {
            if(platformObstacle.platformObstacleType == PlatformObstacle_TYPE.TRIGGER_MOVE)
            {
                platformObstacle.ManualMove();                             
            }
        }        
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag(ProjectConstants.TAG_PLAYER))
        {
            if(platformObstacle.platformObstacleTrapType == PlatformObstacle_TRAPTYPE.CRUMBLING)
            {
                platformObstacle.trapTime -= Time.deltaTime;

                if(platformObstacle.trapTime <= 0.0f)
                {
                    platformObstacle.platform.SetActive(false);    

                    platformObstacle.ResetTrap_External();                                
                }                                                                    
            }

            else if(platformObstacle.platformObstacleTrapType == PlatformObstacle_TRAPTYPE.SPIKE)
            {
                platformObstacle.trapTime -= Time.deltaTime;

                if(platformObstacle.trapTime <= 0.0f)
                {
                    //Appear the spike mesh

                    //Damage player by some value
                    PlayerStat.Instance.DamagePlayer(platformObstacle.damage);
                    Debug.Log("You have been hit by spike !, so you lose health");

                    //Reset trap
                    platformObstacle.ResetTrap_External();
                }     
            }
        }                
    }

    private void OnTriggerExit(Collider other) 
    {
        //Reset any trap if there is no player
        if(other.gameObject.CompareTag(ProjectConstants.TAG_PLAYER))
        {
            platformObstacle.ResetTrap_External(0.0f);          
        }          
    }
}
