using UnityEngine;

public class State_JumpUp : FSMStateV5
{
    public float jumpUpTime = 5.0f;

    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {
        //Play animation at the start
        fsmStateManager.ChangeToNewAnimation(fsmStateManager.GetAnimationName(startAnimation));
    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        #region ACTIONS

        #endregion ACTIONS

        #region CONDITION SWITCH STATE
        //if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed, jumpUpTime))
        //{
        //    //Change to jump down state
        //    fsmStateManager.TransitionToState(nextState);
        //}

        if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed, jumpUpTime))
        {
            fsmStateManager.TransitionToState(nextState);
        }
        #endregion CONDITION SWITCH STATE
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }
}
