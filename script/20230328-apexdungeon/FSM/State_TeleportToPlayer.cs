using UnityEngine;

public class State_TeleportToPlayer : FSMStateV5
{    
    public override void State_StartLogic(FSMStateManager fSMStateManager)
    {
        //Teleport to player
        enemyCore.TeleportTo(MasterGameSystem.Instance.player.transform.position + (Vector3.one * 3));

        //Change to new state
        fSMStateManager.TransitionToState(nextState);
    }

    public override void State_LoopLogic(FSMStateManager fSMStateManager)
    {
        
    }

    public override void State_EndLogic(FSMStateManager fSMStateManager)
    {

    }
}
