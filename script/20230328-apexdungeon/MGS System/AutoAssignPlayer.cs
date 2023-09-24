using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAssignPlayer : MonoBehaviour
{
    void Start()
    {
        MasterGameSystem.Instance.player = this.gameObject;        
    }
}
