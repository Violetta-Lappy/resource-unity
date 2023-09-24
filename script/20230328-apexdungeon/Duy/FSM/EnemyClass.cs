using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 10/11/2021
Object(s) holding this script: Enemy
Summary: 

*****************************************************************************************************************************/

[RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
public class EnemyClass : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    FiniteStateMachine finiteStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        finiteStateMachine = this.GetComponent<FiniteStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
