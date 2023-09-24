using System.Collections;
using UnityEngine;

public class ComponentConnector : MonoBehaviour {

    public Transform m_startTransform;
    public Transform m_endTransform;

    public float f_rate = 0.5f;

    void Start() => ResizeConnector(m_startTransform.position, m_endTransform.position);
    void Update() => ResizeConnector(m_startTransform.position, m_endTransform.position);

    //reposition to middle of two vector, resize the middle between two vector
    void ResizeConnector(Vector3 _startVector, Vector3 _endVector) {
        Vector3 dir = _endVector - _startVector;
        Vector3 middle = (dir) / 2.0f + _startVector;

        transform.position = middle;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);

        Vector3 scale = transform.localScale;

        scale.y = dir.magnitude * f_rate;

        transform.localScale = scale;
    }
}