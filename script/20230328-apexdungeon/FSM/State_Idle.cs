public class State_Idle : FSMStateV5
{
    public float idleTime = 1.0f;

    public override void State_StartLogic(FSMStateManager fSMStateManager)
    {
        //Play animation at the start
        fSMStateManager.ChangeToNewAnimation(fSMStateManager.GetAnimationName(startAnimation));

        enemyCore.StopWalking();
    }

    public override void State_LoopLogic(FSMStateManager fSMStateManager)
    {
        //Check condition and transit to next state
        if (fSMStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed, idleTime))
        {
            fSMStateManager.TransitionToState(nextState);
        }
    }

    public override void State_EndLogic(FSMStateManager fSMStateManager)
    {

    }
}
