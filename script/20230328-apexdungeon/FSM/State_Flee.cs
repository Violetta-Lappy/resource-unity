using UnityEngine;

public class State_Flee : FSMStateV5
{
    [Header("State Settings")]
    public float fleeSpeed = 10.0f;
    public float fleeTime = 5.0f;

    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {
        //Play animation at the start
        fsmStateManager.ChangeToNewAnimation(fsmStateManager.GetAnimationName(startAnimation));
    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        #region ACTIONS
        //Enemy wander around
        enemyCore.FleeFromPlayer(fleeSpeed);
        #endregion ACTIONS

        #region CONDITION SWITCH STATE
        if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed, fleeTime))
        {
            //Change to wander state
            fsmStateManager.TransitionToState(nextState);
        }
        #endregion CONDITION SWITCH STATE
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }
}
