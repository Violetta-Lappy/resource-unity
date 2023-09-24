using UnityEngine;

public class State_JumpDown : FSMStateV5
{
    public float recoveryTime = 3.0f;
    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {
        //Play animation at the start
        fsmStateManager.ChangeToNewAnimation(fsmStateManager.GetAnimationName(startAnimation));

        //Not allow to walk
        enemyCore.StopWalking();
    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed, recoveryTime))
        {
            //Change to jump down state
            fsmStateManager.TransitionToState(nextState);
        }
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }
}
