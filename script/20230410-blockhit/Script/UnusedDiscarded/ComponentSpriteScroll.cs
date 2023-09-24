using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSpriteScroll : MonoBehaviour {
    private float f_scrollSpeed;
    private float f_rightEdge;
    private float f_leftEdge;
    private Vector3 vec3_distanceBetweenEdges;

    void Start() {
        CalculateEdges();
        vec3_distanceBetweenEdges = new Vector3(f_rightEdge - f_leftEdge, 0f, 0f);
    }

    void Update() {

    }

    private void CalculateEdges() {
        SpriteRenderer temp = GetComponent<SpriteRenderer>();
        f_rightEdge = transform.position.x + temp.bounds.extents.x / 3f;
        f_leftEdge = transform.position.x - temp.bounds.extents.x / 3f;
    }
}
