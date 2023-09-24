using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 1/11/2021
Object(s) holding this script: PlayerThrow
Summary: 
Throw object and visualize its path.
Cut the trajectory line when it hit an object in LayerMask
***************************/

public class ThrowTrajectory : MonoBehaviour
{
    public float throwForce = 5f; //speed object blasts out of player
    public float throwSpeed = 5f; //speed object blasts out of player
    public GameObject objectThrow;
    public Transform throwPos;
    private LineRenderer lineRenderer;
    public int numPoints = 50; //number of points on line
    public float pointsDistance = 0.1f; //distance between points on line
    public LayerMask lineLayer; //layers that cut the line
    public float hitDistance = 0.5f; //distance to object in LayerMask
    public float lineStartWidth = 0.25f; //width of the start of the line
    public float lineEndWidth = 0.25f; //width of the end of the line


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(lineStartWidth, lineEndWidth); //set lineRenderer width
    }

    // Update is called once per frame
    void Update()
    {
        //test code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Throw();
        }

        Trajectory();
    }

    void Trajectory()
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> allPoints = new List<Vector3>();
        Vector3 startPos = throwPos.position;
        Vector3 startVeloc = throwPos.up * throwForce;

        for (float t = 0; t < numPoints; t += pointsDistance)
        {
            Vector3 newPoint = startPos + t * startVeloc;
            newPoint.y = startPos.y + startVeloc.y * t + Physics.gravity.y / 2f * t * t;
            allPoints.Add(newPoint);

            //when hit another object
            if (Physics.OverlapSphere(newPoint, hitDistance, lineLayer).Length > 0)
            {
                lineRenderer.positionCount = allPoints.Count;
                break;
            }
        }
        lineRenderer.SetPositions(allPoints.ToArray());
    }

    void Throw()
    {
        GameObject thrownObj = Instantiate(objectThrow, throwPos.position, throwPos.rotation);
        thrownObj.GetComponent<Rigidbody>().velocity = throwPos.up * throwForce; 
    }
}
