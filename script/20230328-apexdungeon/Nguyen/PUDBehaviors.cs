using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PUDBehaviors : MonoBehaviour
{
    public float duration;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        Floating();
        SelfDestroy();
    }

    private void Floating()
    {
        transform.DOMoveY(transform.position.y + yOffset, duration);
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject, duration);
    }
}
