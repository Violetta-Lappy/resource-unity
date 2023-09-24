using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentAutoMove : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    private float f_screenBoundary;

    private void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();

        f_screenBoundary = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    private void FixedUpdate()
    {
        if (this.transform.position.x < f_screenBoundary)
        {
            GameObject.Destroy(this.gameObject);
        }

        m_Rigidbody.MovePosition(this.transform.position + Vector3.left * Time.deltaTime * ManagerGame.Instance.f_gameSpeed);
    }
}
