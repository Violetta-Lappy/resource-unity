using UnityEngine;

public class State_AttackMelee : FSMStateV5
{
    [Header("State Settings")]
    public GameObject damageObject;
    public float rotationRate = 1.0f;

    public FSMStateV5 state01;
    public ENUM_FSM_CONDITION_TYPE atkConditionType = ENUM_FSM_CONDITION_TYPE.IsPlayerNotInAttackRange;

    public FSMStateV5 state02;
    public ENUM_FSM_CONDITION_TYPE otherConditionType = ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed;

    public float attackTime = 10.0f;

    public override void State_StartLogic(FSMStateManager fSMStateManager)
    {
        //Play animation at the start
        fSMStateManager.PlayForceAnimation(fSMStateManager.GetAnimationName(startAnimation));

        //Setup attack melee
        enemyCore.Setup_AttackMelee(damageObject);
    }

    public override void State_LoopLogic(FSMStateManager fSMStateManager)
    {
        enemyCore.StopWalking();

        //Rotate towards
        enemyCore.RotateTowards(MasterGameSystem.Instance.player.transform, rotationRate);

        //Check condition and transit to next state        
        if (fSMStateManager.CheckSpecificCondition(atkConditionType, attackTime))
        {
            //Do not run below code if there is no state
            if (state01 == null) return;

            //Should change to Attack Range State
            fSMStateManager.TransitionToState(state01);
        }

        //Check condition and transit to next state        
        else if (fSMStateManager.CheckSpecificCondition(otherConditionType, attackTime))
        {
            //Do not run below code if there is no state
            if (state02 == null) return;

            //Should change to Attack Range State
            fSMStateManager.TransitionToState(state02);
        }
    }

    public override void State_EndLogic(FSMStateManager fSMStateManager)
    {

    }
}
