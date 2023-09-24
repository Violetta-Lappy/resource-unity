using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    private Vector3 gizmoisPos;


    private void OnDrawGizmos()
    {
        for(float i = 0; i <= 1; i += 0.05f)
        {
            gizmoisPos = Mathf.Pow(1 - i, 3) * points[0].position +
                3 * Mathf.Pow(1 - i, 2) * i * points[1].position +
                3 * (1 - i) * Mathf.Pow(i, 2) * points[2].position +
                Mathf.Pow(i, 3) * points[3].position;

            Gizmos.DrawSphere(gizmoisPos, 0.25f);
        }

        Gizmos.DrawLine(new Vector3(points[0].position.x, points[0].position.y, points[0].position.z), new Vector3(points[1].position.x, points[1].position.y, points[1].position.z));

        Gizmos.DrawLine(new Vector3(points[2].position.x, points[2].position.y, points[2].position.z), new Vector3(points[3].position.x, points[3].position.y, points[3].position.z));

    }
}
