using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 02/11/2021
Object(s) holding this script: Player
Summary: 
Handles player's movements 
*****************************************************************************************************************************/

//Check different states status
//Dictate whether or not the state itself is active 
public enum ExecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

//Abstract allow any class that inherits from this class will have to write the body of code
//Virtual allow other function to override if needed
public abstract class AbstractFSMState : ScriptableObject
{
    protected NavMeshAgent navMeshAgent;
    public ExecutionState executionState { get; protected set; }

    public virtual void OnEnable()
    {
        executionState = ExecutionState.NONE;
    }

    public virtual bool EnterState()
    {
        executionState = ExecutionState.ACTIVE;
        
        return true;
    }

    //Allow to constrant on the tick
    public abstract void UpdateState();
    
    //Allow to override
    public virtual bool ExitState()
    {
        executionState = ExecutionState.COMPLETED;
        return true;
    }

    public virtual void SetNavMeshAgent(NavMeshAgent navMeshAgent)
    {

    }
}