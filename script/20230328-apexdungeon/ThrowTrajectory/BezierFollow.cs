using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{

    [SerializeField]  private Transform curve;
    private Vector3 thrownObjPos;
    [SerializeField] private float speedModifier;
    private bool startFollow = true;
    private float speed=0;

    // Update is called once per frame
    private void Update()
    {

        if (startFollow)
        {
            StartCoroutine(FollowTheCurve());
        }



    }


    private IEnumerator FollowTheCurve()
    {
        
        startFollow = false;
        Vector3 point0 = curve.GetChild(0).position;
        Vector3 point1 = curve.GetChild(1).position;
        Vector3 point2 = curve.GetChild(2).position;
        Vector3 point3 = curve.GetChild(3).position;
        
        while (speed < 1)
        {
            speed += Time.deltaTime * speedModifier;

            thrownObjPos = Mathf.Pow(1 - speed, 3) * point0 +
            3 * Mathf.Pow(1 - speed, 2) * speed * point1 +
            3 * (1 - speed) * Mathf.Pow(speed, 2) * point2 +
            Mathf.Pow(speed, 3) * point3;

            transform.position = thrownObjPos;
            Debug.Log(thrownObjPos);
            yield return new WaitForEndOfFrame();
        }

        speed = 0f;

       // startFollow = true;


    }
}
