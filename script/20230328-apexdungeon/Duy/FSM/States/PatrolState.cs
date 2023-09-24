using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 20/10/2021
Object(s) holding this script: Enemy
Summary: 

*****************************************************************************************************************************/

[CreateAssetMenu(fileName = "PatrolState", menuName = "FSM/States/Patrol", order = 2)]

public class PatrolState : AbstractFSMState
{
    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override bool EnterState()
    {
        base.EnterState();

        Debug.Log("Entered patrol state");

        return true;
    }

    public override void UpdateState()
    {
        Debug.Log("Updating patrol state");
    }

    public override bool ExitState()
    {
        base.ExitState();

        Debug.Log("Exitting patrol state");

        return true;
    }
}
