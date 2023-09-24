using UnityEngine;

public class State_OnAir : FSMStateV5
{
    public float onAirSpeed = 5.0f;
    public float onAirTime = 5.0f;

    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {
        //Play animation at the start
        fsmStateManager.ChangeToNewAnimation(fsmStateManager.GetAnimationName(startAnimation));
    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        //Move towards enemy
        enemyCore.SetDestinationAndSpeed(MasterGameSystem.Instance.GetPlayerPos(), onAirSpeed);
        
        #region CONDITION SWITCH STATE
        //Check condition and transit to next state        
        if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInAttackRange))
        {
            //Change to jump down state
            fsmStateManager.TransitionToState(nextState);
        }        

        else if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed, onAirTime))
        {
            //Change to jump down state
            fsmStateManager.TransitionToState(nextState);
        }
        #endregion CONDITION SWITCH STATE
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }
}
