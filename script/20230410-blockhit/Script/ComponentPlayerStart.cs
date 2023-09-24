using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPlayerStart : MonoBehaviour
{
    private void Start() {        
        if (ManagerGameValue.Instance != null) ManagerGameValue.Instance.SetComponentPlayerStart(this);
        if (ControllerPlayer.Instance != null) ControllerPlayer.Instance.SetRootPosition(this.transform.position);
    }
}
