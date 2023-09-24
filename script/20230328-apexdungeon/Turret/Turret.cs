using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float duration = 0.5f;
    public float force = 100.0f;
    public float rotationSpeed = 0.2f;
    public GameObject prefab;
    public Transform shootingPos;
    public Transform target;
    
    void Start()
    {
         
    }
    
    void Update()
    {
        if(target != null)
        {
            //this.transform.LookAt(target.transform.position);              

            Vector3 RotateToTarget = new Vector3(target.position.x, 0, target.position.z);
        
            var rotate = Quaternion.LookRotation(RotateToTarget - transform.localPosition);

            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotate, rotationSpeed);

            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);                     
        }        
    }

    public void ActivateGun(Transform playerPos)
    {
        InvokeRepeating("FireGun", duration, duration);  

        target = playerPos;
    }

    public void FireGun()
    {               
        GameObject bullet = Instantiate(prefab, shootingPos.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(shootingPos.forward * force, ForceMode.Impulse);             
    }

    public void DeactivateFireGun()
    {           
        CancelInvoke("FireGun");
    }
}
