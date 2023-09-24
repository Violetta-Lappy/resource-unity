using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_DAMAGE_SENSOR_TYPE
{
    COLLISION,
    TRIGGER
}

public class DamageSensor : MonoBehaviour
{
    public ENUM_DAMAGE_SENSOR_TYPE damageSensorType;
    public int damageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if(damageSensorType == ENUM_DAMAGE_SENSOR_TYPE.COLLISION)
        {
            DamageStuff(collision.gameObject);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (damageSensorType == ENUM_DAMAGE_SENSOR_TYPE.TRIGGER)
        {
            DamageStuff(other.gameObject);
        }
    }

    public void DamageStuff(GameObject stuff)
    {
        //Damage the player or the enemy
        //Debug.Log("Something detected, attempt damage but no logic");

        if(stuff != null)
        {
            PlayerHealth playerHealth = stuff.GetComponent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.Damage(damageValue);
            }
        }
    }
}
