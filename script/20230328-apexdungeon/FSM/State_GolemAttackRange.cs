using UnityEngine;

public class State_GolemAttackRange : FSMStateV5
{
    [Header("State Settings")]
    public GameObject shootingLocation;
    public GameObject projectilePrefab;
    public ForceMode forceMode = ForceMode.Impulse;
    public float projectileForce = 30.0f;

    [Header("Golem States")]
    public FSMStateV5 walkState;
    public FSMStateV5 attackMeleeState;

    public override void State_StartLogic(FSMStateManager fSMStateManager)
    {
        //Play animation at the start
        fSMStateManager.ChangeToNewAnimation(fSMStateManager.GetAnimationName(startAnimation));

        //Stop moving
        enemyCore.StopWalking();
    }

    public override void State_LoopLogic(FSMStateManager fSMStateManager)
    {
        //Check condition and transit to next state
        if (!fSMStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInLOS))
        {
            //Change to move towards state
            fSMStateManager.TransitionToState(walkState);
        }

        else if (fSMStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInAttackRange))
        {
            //Change to melee state
            fSMStateManager.TransitionToState(attackMeleeState);
        }
    }

    public override void State_EndLogic(FSMStateManager fSMStateManager)
    {

    }

    public void AttackPlayer_Range(Vector3 targetLocation)
    {
        shootingLocation.transform.LookAt(targetLocation);

        Rigidbody rigidbody = Instantiate(projectilePrefab, shootingLocation.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rigidbody.AddForce(shootingLocation.transform.forward * projectileForce, forceMode);

        //rigidbody.GetComponent<EnemyBulletBehavior>().rotateDir = transform.localRotation.eulerAngles.y;
        //rigidbody.AddForce(transform.up * 8.0f, ForceMode.Impulse);        
    }
}
