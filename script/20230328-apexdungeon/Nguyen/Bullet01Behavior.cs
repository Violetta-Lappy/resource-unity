using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************************
Author: DUONG DUC NGUYEN
Date Made: 20/10/2021
Object(s) holding this script: Bullet01 prefab
Summary: 

*****************************************************************************************************************************/

public class Bullet01Behavior : MonoBehaviour
{
    public float bulletSpeed; //Bullets' moving speed
    private GameObject baseGun; //Gun game object
    public float rotateDir; //rotation of the bullet

    //Check bool
    private bool causingDmg = false;
    public bool repeating = true;

    public float dmgRepeatRate = 0.1f;
    public int dmgAmount = 1;

    // Start is called before the first frame update
    public virtual void Start()
    {
        baseGun = GameObject.Find("BaseGun");
        rotateDir = GameObject.Find("Player").transform.localRotation.eulerAngles.y;

        MoveForward();
        SelfDestroy();

        //Debug.Log(transform.localRotation.eulerAngles.x + " , " + transform.localRotation.eulerAngles.y + " , " + transform.localRotation.eulerAngles.z);
    }


    //Set rotation and make the bullet move forward
    //Called in Start()
    public virtual void MoveForward()
    {
        this.transform.rotation = Quaternion.Euler(90, rotateDir, 0); 
        Rigidbody bullet = this.GetComponent<Rigidbody>();
        bullet.velocity = baseGun.transform.forward * bulletSpeed;
    }

    //Destroy game object after 5s
    //Called in Update()
    void SelfDestroy()
    {
        Destroy(this.gameObject, 5f);
    }

    //Check to see if it hit player
    //Apply damage
    private void OnTriggerEnter(Collider col)
    {
        causingDmg = true;

        if (col.GetComponent<GeneralHealth>() != null)
        {
            col.GetComponent<GeneralHealth>().TakeDamage(10);

            print("hit");
        }

    }
}
