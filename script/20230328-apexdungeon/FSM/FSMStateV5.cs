using UnityEngine;

[SerializeField]
public abstract class FSMStateV5 : MonoBehaviour
{
    [Header("General State Settings")]
    public FSMStateV5 nextState;

    [Header("General Behavior Settings")]
    public ENUM_ENEMY_ANIMATION_STATE_TYPE startAnimation = ENUM_ENEMY_ANIMATION_STATE_TYPE.NONE;    

    //Reference Variable
    [HideInInspector] public LongBaseEnemy enemyCore;

    public abstract void State_StartLogic(FSMStateManager fSMStateManager);
    public abstract void State_LoopLogic(FSMStateManager fSMStateManager);
    public abstract void State_EndLogic(FSMStateManager fSMStateManager);
}
