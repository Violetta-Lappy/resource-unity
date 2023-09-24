using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = CheckpointManager.Instance.lastRoom;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
