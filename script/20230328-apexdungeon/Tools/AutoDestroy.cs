using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{    
    public float destroyTime = 10.0f;
    void Start()
    {
        //Destroy this current object for a set time
        Destroy(this.gameObject, destroyTime);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && !other.gameObject.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
        }
    }
    */
}
