using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    void Awake()
    {
        //Debug.Log("yo");
        gameObject.SetActive(true);        
    }
}
