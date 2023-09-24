using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 20/10/2021
Object(s) holding this script: Enemy
Summary: 
*****************************************************************************************************************************/

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] AbstractFSMState startingState;
    AbstractFSMState currentState;

    public void Awake()
    {
        currentState = null;
    }

    public void Start()
    {
        if (startingState != null)
        {
            EnterState(startingState);
        }
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    #region STATE MANAGEMENT

    public void EnterState(AbstractFSMState nextState)
    {
        if (nextState == null)
        {
            return;
        }

        currentState = nextState;
        currentState.EnterState();
    }

    #endregion
}
