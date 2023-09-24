public class State_Walk : FSMStateV5
{
    public float walkSpeed = 10.0f;
    public float walkTime = 10.0f;
    public bool allowAnimationCancel = false;
    public ENUM_FSM_CONDITION_TYPE walkConditionType = ENUM_FSM_CONDITION_TYPE.IsPlayerInAttackRange;

    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {

    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsAnimationDone))
        {
            //Play animation at the start
            if (allowAnimationCancel)
            {
                fsmStateManager.PlayForceAnimation(fsmStateManager.GetAnimationName(startAnimation));
            }

            else if (allowAnimationCancel == false)
            {
                fsmStateManager.ChangeToNewAnimation(fsmStateManager.GetAnimationName(startAnimation));
            }


            //Stop walking
            enemyCore.SetDestinationAndSpeed(MasterGameSystem.Instance.GetPlayerPos(), walkSpeed);
        }

        //Check condition and transit to next state        
        if (fsmStateManager.CheckSpecificCondition(walkConditionType, walkTime))
        {
            //Change to attack melee state
            fsmStateManager.TransitionToState(nextState);
        }
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }
}
