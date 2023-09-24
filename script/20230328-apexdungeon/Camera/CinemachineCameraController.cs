using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CinemachineCameraController : MonoBehaviour
{
    public static CinemachineCameraController instance;
    
    [SerializeField] private Transform lookAhead; //Transform of the look ahead point
    [SerializeField] private Transform player; //Reference to the player transform
    [SerializeField] private float maxDistance = 4; //The maximum distance between the player and the look ahead
    [FormerlySerializedAs("camera")] [SerializeField] private Camera mainCam;
    [SerializeField] private float cameraMoveSpeed;
    [SerializeField] private Transform mousePosRef;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    public float xMinBound, xMaxBound, zMinBound, zMaxBound; 
    
    private Vector3 mousePos;
    private float elapsedTime;
    private CinemachineBasicMultiChannelPerlin multiChannelPerlin;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    private void Start()
    {
        multiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        Debug.DrawLine(player.position, mousePos, Color.red);
        
        ChangingLookAheadPosition();
        
        if (multiChannelPerlin != null)
        {
            if (elapsedTime > 0)
            {
                elapsedTime -= Time.deltaTime;
            }
            else
            {
                multiChannelPerlin.m_AmplitudeGain = 0;
                multiChannelPerlin.m_FrequencyGain = 0;
            }
        }
    }
    
    void ChangingLookAheadPosition()
    {
        Plane plane = new Plane(Vector3.up, -2.35f);
        
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            mousePos = ray.GetPoint(distance);

            //print(mousePos);

        }

        Vector3 tempPos = (player.position + mousePos) / 2f;

        lookAhead.position = tempPos;

        if (mousePosRef != null)
        {
            mousePosRef.position = mousePos;
        }
        
        lookAhead.localPosition = Vector3.ClampMagnitude(lookAhead.localPosition, maxDistance);
        
        if(lookAhead.transform.position.x > xMaxBound)
        {
            lookAhead.transform.position =
                new Vector3(xMaxBound, lookAhead.transform.position.y, lookAhead.transform.position.z);
        }
        if(lookAhead.transform.position.z > zMaxBound) {
            lookAhead.transform.position =
                new Vector3(lookAhead.transform.position.x, lookAhead.transform.position.y, zMaxBound);
        }
        if(lookAhead.transform.position.x < xMinBound) {
            lookAhead.transform.position =
                new Vector3(xMinBound, lookAhead.transform.position.y, lookAhead.transform.position.z);
        }
        if(lookAhead.transform.position.z < zMinBound) {
            lookAhead.transform.position =
                new Vector3(lookAhead.transform.position.x, lookAhead.transform.position.y, zMinBound);
        }
    }

    public void ScreenShake(float intensity,float duration, float frequency)
    {
        if (multiChannelPerlin == null) return;

        multiChannelPerlin.m_AmplitudeGain = intensity;
        multiChannelPerlin.m_FrequencyGain = frequency;
        elapsedTime = duration;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mousePos, .2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(lookAhead.position, .2f);
    }
}
