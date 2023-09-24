using UnityEngine;

public class State_Bomb : FSMStateV5
{
    [Header("State Settings")]
    //No need to have timeToBomb, when switch to this state go boom suddenly
    public GameObject hitbox;

    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {
        //Play animation at the start
        fsmStateManager.PlayForceAnimation(fsmStateManager.GetAnimationName(startAnimation));

        enemyCore.Setup_Bomb(hitbox);
    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        enemyCore.SetDestinationAndSpeed(MasterGameSystem.Instance.GetPlayerPos(), 5.0f);
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }
}
