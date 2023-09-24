using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_FSM_CONDITION_TYPE
{
    IsPlayerInLOS,
    IsPlayerInAttackRange,
    IsWaitTimeExceed,
    IsPlayerNotInLOS,
    IsPlayerNotInAttackRange,
    IsAnimationDone    
}

public enum ENUM_ENEMY_ANIMATION_STATE_TYPE
{
    NONE,
    IDLE,
    WALK,
    RUN,
    ATTACK_MELEE,
    ATTACK_RANGE,
    JUMP_UP,
    ON_AIR,
    JUMP_DOWN,
    SPAWN_OBJECTS,
    BOMB
}

public class FSMStateManager : MonoBehaviour
{
    public FSMStateV5 currentFSMState;
    public FSMStateV5 previousFSMState;
    private FSMStateV5 idleFSMState;

    public float waitTime;   

    [Header("Animator Settings")]
    public Animator mainAnimator;
    public string currentAnimationName; 
    public string newAnimationName;
    public bool isAnimationDone = false;
    public float animationTime;
    
    void Start()
    {
        //Init FSM Brain V5
        previousFSMState = currentFSMState;

        //The emergency state should be Idle Only
        idleFSMState = currentFSMState;

        //Start the state at the first frame, CurrentState should be set up with Idle
        currentFSMState.enemyCore = this.transform.parent.GetComponent<LongBaseEnemy>();
        currentFSMState.State_StartLogic(this);

        //Setup to idle animation
        mainAnimator = this.transform.parent.GetComponent<Animator>();
        currentAnimationName = GetAnimationName(ENUM_ENEMY_ANIMATION_STATE_TYPE.IDLE);
        newAnimationName = GetAnimationName(ENUM_ENEMY_ANIMATION_STATE_TYPE.IDLE);
        StartCoroutine(PlayAndWaitAnimation());
    }

    void Update()
    {
        //Update the current state       
        currentFSMState.State_LoopLogic(this);
    }

    public bool CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE fsmConditionType, float compareValue = 0.0f)
    {
        switch (fsmConditionType)
        {
            case ENUM_FSM_CONDITION_TYPE.IsPlayerInLOS: return this.transform.parent.GetComponent<LongBaseEnemy>().Get_PlayerInLOSStatus();
            case ENUM_FSM_CONDITION_TYPE.IsPlayerInAttackRange: return this.transform.parent.GetComponent<LongBaseEnemy>().Get_PlayerInAttackRangeStatus();
            case ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed: return (waitTime += Time.deltaTime) > compareValue;
            case ENUM_FSM_CONDITION_TYPE.IsPlayerNotInLOS: return this.transform.parent.GetComponent<LongBaseEnemy>().Get_PlayerInLOSStatus() == false ? true : false;
            case ENUM_FSM_CONDITION_TYPE.IsPlayerNotInAttackRange: return this.transform.parent.GetComponent<LongBaseEnemy>().Get_PlayerInAttackRangeStatus() == false ? true : false;            
            case ENUM_FSM_CONDITION_TYPE.IsAnimationDone: return isAnimationDone;

            default: return false;
        }
    }

    public string GetAnimationName(ENUM_ENEMY_ANIMATION_STATE_TYPE enemyAnimationType)
    {
        switch (enemyAnimationType)
        {
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.NONE: 
            Debug.Log("Enemy just play wrong animation !!");
            return "Anim_AOC_None";
            
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.IDLE: return "IDLE";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.WALK: return "WALK";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.RUN: return "RUN";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.ATTACK_MELEE: return "ATTACK MELEE";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.ATTACK_RANGE: return "ATTACK RANGE";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.JUMP_UP: return "JUMP UP";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.ON_AIR: return "ON AIR";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.JUMP_DOWN: return "JUMP DOWN";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.SPAWN_OBJECTS: return "SPAWN OBJECTS";
            case ENUM_ENEMY_ANIMATION_STATE_TYPE.BOMB: return "BOMB";

            default: return "Enemy Animation Name has not been set up yet !!";
        }
    }

    public void ChangeToNewAnimation(string animationName)
    {
        newAnimationName = animationName;
    }

    private IEnumerator PlayAndWaitAnimation()
    {
        //Change to new animation name
        if(currentAnimationName != newAnimationName)
        {
            currentAnimationName = newAnimationName;
        }

        //Animation is now playing
        isAnimationDone = false;

        
        animationTime = mainAnimator.GetCurrentAnimatorStateInfo(0).length;
        mainAnimator.Play(currentAnimationName);
        //Waiting for current animation to be done
        yield return new WaitForSeconds(animationTime);
        //yield return new WaitForSeconds(mainAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        //Animation has done playing
        isAnimationDone = true;

        //Wait for a frame before continue
        //yield return new WaitForEndOfFrame();
        //yield return 0;

        yield return null;
        
        //Update the new animation
        StartCoroutine(PlayAndWaitAnimation());
    }

    public void PlayForceAnimation(string animationName)
    {
        StopAllCoroutines();

        newAnimationName = animationName;
        currentAnimationName = newAnimationName;
        StartCoroutine(PlayAndWaitAnimation());
    }

    public void TransitionToState(FSMStateV5 nextEnemyState)
    {
        //If we already in the same state, there is no reason to switch the state
        if (nextEnemyState != currentFSMState)
        {
            //Execute Exit Logic first and once, before changing to a new state
            currentFSMState.State_EndLogic(this);

            //Reset all conditions
            ResetCondition();

            //Get the previous state
            previousFSMState = currentFSMState;

            //Set to the next state
            currentFSMState = nextEnemyState;

            //Execute Start Logic first and once, after changing to a new state
            currentFSMState.enemyCore = this.transform.parent.GetComponent<LongBaseEnemy>();
            currentFSMState.State_StartLogic(this);
        }
    }

    public void ResetToIdleState()
    {
        //Execute Exit Logic first and once, before changing to a new state
        currentFSMState.State_EndLogic(this);

        //Reset all conditions
        ResetCondition();

        //Get the previous state
        previousFSMState = currentFSMState;

        //Set to the next state
        currentFSMState = idleFSMState;

        //Execute Start Logic first and once, after changing to a new state
        currentFSMState.State_StartLogic(this);
    }

    public void ResetCondition()
    {
        waitTime = 0.0f;        
    }    
}
