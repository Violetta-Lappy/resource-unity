using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementDebugger : MonoBehaviour
{
    public TextMeshPro textDebugger;
    public EnemyHealth healthRef;
    public TextMeshPro healthDebugger;

    private void Start()
    {
        healthRef = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthRef != null)
        {
            textDebugger.text = healthRef.GetCurrentStatus().ToString();
            healthDebugger.text = healthRef.currentHealth.ToString();
            switch (healthRef.GetCurrentStatus())
            {
                case Status.Fire:
                    textDebugger.color = Color.red;
                    break;
                case Status.Water:
                    textDebugger.color = Color.blue;

                    break;
                //case Status.Nature:
                //    textDebugger.color = Color.green;

                    break;
                case Status.Electric:
                    textDebugger.color = Color.magenta;

                    break;
                case Status.None:
                    textDebugger.color = Color.white;

                    break;
            }
        }
    }
}
