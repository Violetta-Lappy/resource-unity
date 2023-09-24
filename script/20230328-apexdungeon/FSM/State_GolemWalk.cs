public class State_GolemWalk : FSMStateV5
{
    [UnityEngine.Header("Golem Next States")]
    public FSMStateV5 attackMeleeState;
    public FSMStateV5 attackRangeState;
    public FSMStateV5 jumpTowardState;

    public float walkSpeed = 10.0f;
    public float walkTime = 10.0f;

    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {
        //Play animation at the start
        fsmStateManager.ChangeToNewAnimation(fsmStateManager.GetAnimationName(startAnimation));
    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        enemyCore.SetDestinationAndSpeed(MasterGameSystem.Instance.GetPlayerPos(), walkSpeed);

        //Check condition and transit to next state
        if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInAttackRange))
        {
            //Switch to attack melee when player in attack range
            fsmStateManager.TransitionToState(attackMeleeState);
        }

        else if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInLOS))
        {
            //Switch to attack range when enemy see the player
            fsmStateManager.TransitionToState(attackRangeState);
        }        

        else if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed, walkTime))
        {
            //Switch to jump towards player when golem wait long time
            fsmStateManager.TransitionToState(jumpTowardState);
        }
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }
}
