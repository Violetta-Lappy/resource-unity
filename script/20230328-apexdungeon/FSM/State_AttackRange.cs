using UnityEngine;

public class State_AttackRange : FSMStateV5
{
    [Header("Range Attack Settings")]
    public Transform[] atkRangeLocations;
    public GameObject projectilePrefab;
    public float projectileForce = 30.0f;
    public bool isShootAll = false;
    public float rotationRate = 1.0f;

    [Header("State Settings")]
    public FSMStateV5 state01;
    public ENUM_FSM_CONDITION_TYPE rangeConditionType = ENUM_FSM_CONDITION_TYPE.IsPlayerNotInLOS;

    public FSMStateV5 state02;
    public ENUM_FSM_CONDITION_TYPE otherConditionType = ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed;

    public float attackTime = 10.0f;

    [Header("Boss Settings")]
    public bool isWalkRandomly = false;

    public override void State_StartLogic(FSMStateManager fSMStateManager)
    {
        //Play animation at the start
        fSMStateManager.PlayForceAnimation(fSMStateManager.GetAnimationName(startAnimation));

        //Setup atk range
        enemyCore.Setup_AttackRange(projectilePrefab, projectileForce, atkRangeLocations, isShootAll);
    }

    public override void State_LoopLogic(FSMStateManager fSMStateManager)
    {
        if (isWalkRandomly == false)
        {
            //Do not walk when shooting
            enemyCore.StopWalking();
        }

        if (isWalkRandomly == true)
        {
            enemyCore.Wander(20, 100);
        }

        //Rotate towards
        enemyCore.RotateTowards(MasterGameSystem.Instance.player.transform, rotationRate);

        //Check condition and transit to next state        
        if (fSMStateManager.CheckSpecificCondition(rangeConditionType, attackTime))
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
