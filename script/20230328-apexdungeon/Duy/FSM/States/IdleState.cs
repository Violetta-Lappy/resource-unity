using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 20/10/2021
Object(s) holding this script: Enemy
Summary: 

*****************************************************************************************************************************/

[CreateAssetMenu(fileName = "IdleState", menuName = "FSM/States/Idle", order = 1)]
public class IdleState : AbstractFSMState
{
    public override bool EnterState()
    {
        base.EnterState();

        Debug.Log("Entered idle state");

        return true;
    }

    public override void UpdateState()
    {
        //Debug.Log("Updating idle state");
    }

    public override bool ExitState()
    {
        base.ExitState();

        Debug.Log("Exitting idle state");

        return true;
    }
}
