using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 21/10/2021
Object(s) holding this script: TestBullet
Summary: 
Getting bullet component
*****************************************************************************************************************************/

public class TestBullet : MonoBehaviour
{
    Rigidbody bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeSpan();
    }

    void LifeSpan()
    {
        Destroy(gameObject, 1.0f);
    }

    //Testing
    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<GeneralHealth>() != null)
        {
            col.GetComponent<GeneralHealth>().TakeDamage(10);
        }
    }
}
