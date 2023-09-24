using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 08/09/2021
Object(s) holding this script: Camera
Summary: 
Handles camera's controls 
*****************************************************************************************************************************/

//Temp Cam before using cinemachine
public class Camera_Controller : MonoBehaviour
{
    public float mouseSens = 100.0f;

    float mouseX;
    float mouseY;

    float xRotation;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        player.Rotate(Vector3.up * mouseX);
    }
}
