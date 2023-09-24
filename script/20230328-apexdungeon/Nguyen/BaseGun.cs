using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************************
Author: DUONG DUC NGUYEN
Date Made: 20/10/2021
Object(s) holding this script: BaseGun 
Summary: 
Fires bullets with 4 different firing modes
Changes firing mode by scolling middle mouse
*****************************************************************************************************************************/

public class BaseGun : MonoBehaviour
{
    public GameObject bullet01; //The bullet we want to use
    public GameObject firingPoint; //Place where we fire our bullets

    private bool isFiring = false; //The gun is currently firing

    public bool[] firingMode = new bool[4]; //An array store all firing mode
    private int currentMode; //Current firing mode
    private int previousMode; //Previous firing mode

    // Start is called before the first frame update
    void Start()
    {
        //firingPoint = GameObject.Find("_FiringPoint"); //Get the place where we fire our bullet
        currentMode = 0;
        previousMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Firing();
        ChangeFiringMode();
    }

    //Changes firing modes
    //Called in Update()
    void ChangeFiringMode()
    {
        //Middle mouse scolled up
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            previousMode = currentMode; //Previous firing mode now = to current firing mode

            //Drecease current firing mode by 1
            if (currentMode > 0)
            {
                currentMode -= 1;
            }
            else if (currentMode == 0) //If current mode = 0
            {
                //Set it = to the highest element in the array
                currentMode = firingMode.Length - 1;
            }
        }

        //Middle mouse scrolled down
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            previousMode = currentMode;  //Previous firing mode now = to current firing mode

            //If current mode is not = to max length of the array
            if (currentMode != firingMode.Length - 1)
            {
                currentMode += 1; //Increase by 1
            }
            //If current mode is = to max length of the array
            else if (currentMode == firingMode.Length - 1)
            {
                currentMode = 0; //Set it to 0
            }
        }

        firingMode[currentMode] = true; //Set current firing mode to true
        //If current firing mode is not = to previous firing mode
        if (currentMode != previousMode)
        {
            firingMode[previousMode] = false; //Set current firing mode to fasle
        }
        
        /* Name of all firing mode
        isSingleShot = firingMode[0];
        isBurstShot = firingMode[1];
        isAutomatic = firingMode[2];
        isShotgun = firingMode[3];
        */

        //Debug.Log(currentMode + " - " + previousMode);
    }

    //Calls firing modes
    //Called in Update()
    void Firing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (firingMode[0])
            {
                SingleShot();
            }
            else if (firingMode[1] && !isFiring)
            {
                StartCoroutine("BurstShot");
            }
            else if (firingMode[3] && !isFiring)
            {
                StartCoroutine("Shotgun");
            }
        }

        if (firingMode[2])
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                InvokeRepeating("Automatic", 0.1f, 0.1f);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                CancelInvoke();
            }
        }
    }

    //Creates a bullet at the firing point
    //Called by Firing()
    void SingleShot()
    {
        Instantiate(bullet01, firingPoint.transform.position, Quaternion.identity);
       // AudioManager.instance.PlaySound(AudioManager.Sound.TakeDamage);
    }

    //Creates 3 bullets (burst shot) at the firing point
    //Called by Firing()
    IEnumerator BurstShot()
    {
        isFiring = true;

        for (int i = 0; i < 3; i++)
        {
            Instantiate(bullet01, firingPoint.transform.position, Quaternion.identity);
           // AudioManager.instance.PlaySound(AudioManager.Sound.TakeDamage);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);
        isFiring = false;
    }

    //Called by Firing()
    void Automatic()
    {
        Instantiate(bullet01, firingPoint.transform.position, Quaternion.identity);
      //  AudioManager.instance.PlaySound(AudioManager.Sound.TakeDamage);
    }

    //Creates 5 bullets at random position near the firing point
    //Called by Firing()
    IEnumerator Shotgun()
    {
        isFiring = true;

        float xPos = firingPoint.transform.position.x;
        float yPos = firingPoint.transform.position.y;
        float zPos = firingPoint.transform.position.z;

        for (int i = 0; i < 5; i++)
        {
            var firingPosition = new Vector3(Random.Range(xPos + 0.25f, xPos - 0.25f), Random.Range(yPos + 0.1f, yPos - 0.1f), zPos);
            Instantiate(bullet01, firingPosition, Quaternion.identity);
         //   AudioManager.instance.PlaySound(AudioManager.Sound.TakeDamage);
        }
        yield return new WaitForSeconds(1f);

        isFiring = false;
    }
}
