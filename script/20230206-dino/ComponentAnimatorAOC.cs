using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_ANIMATION_STATE_TYPE {
    IDLE,
    RUN,
    JUMPUP,
    ONAIR,
    JUMPDOWN,
}

public class ComponentAnimatorAOC : MonoBehaviour {

    public Animator m_animator;
    public ENUM_ANIMATION_STATE_TYPE enum_currentAnim;
    public ENUM_ANIMATION_STATE_TYPE enum_newAnim;
    public bool isAnimationDone = false;
    public float f_animTime;

    private void Start() {
        m_animator = this.GetComponent<Animator>();
        StartCoroutine(PlayAnimationRoutine(ENUM_ANIMATION_STATE_TYPE.IDLE));
    }    

    private string GetAnimationName(ENUM_ANIMATION_STATE_TYPE type) {
        switch (type) {
            case ENUM_ANIMATION_STATE_TYPE.IDLE: return "IDLE";
            case ENUM_ANIMATION_STATE_TYPE.RUN: return "RUN";
            case ENUM_ANIMATION_STATE_TYPE.JUMPUP: return "JUMPUP";
            case ENUM_ANIMATION_STATE_TYPE.ONAIR: return "ONAIR";
            case ENUM_ANIMATION_STATE_TYPE.JUMPDOWN: return "JUMPDOWN";
            default: Debug.Log("SOMETHING WRONG HAS HAPPEN, NO ANIMATION TO PLAY !!"); return "NONE";
        }
    }
    
    public void ResetAnimationState() { PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE.IDLE); }

    public void PlayAnimation(ENUM_ANIMATION_STATE_TYPE type) {        
        StartCoroutine(PlayAnimationRoutine(type));
    }

    private IEnumerator PlayAnimationRoutine(ENUM_ANIMATION_STATE_TYPE type) {
        enum_newAnim = type;
        if (enum_currentAnim != enum_newAnim) enum_currentAnim = enum_newAnim; //Change to new animation name

        isAnimationDone = false;

        m_animator.Play(GetAnimationName(enum_currentAnim));

        f_animTime = m_animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(f_animTime);

        isAnimationDone = true;       

        yield return OnAnimationDone(enum_currentAnim); //continulous-loop
    }

    public void PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE type) {
        StopAllCoroutines();

        enum_newAnim = type;
        enum_currentAnim = enum_newAnim;

        StartCoroutine(PlayAnimationRoutine(enum_currentAnim));
    }

    private IEnumerator OnAnimationDone(ENUM_ANIMATION_STATE_TYPE type) {
        switch (type) {
            case ENUM_ANIMATION_STATE_TYPE.IDLE: StartCoroutine(PlayAnimationRoutine(ENUM_ANIMATION_STATE_TYPE.IDLE)); break;
            case ENUM_ANIMATION_STATE_TYPE.RUN: StartCoroutine(PlayAnimationRoutine(ENUM_ANIMATION_STATE_TYPE.RUN)); break;
            case ENUM_ANIMATION_STATE_TYPE.JUMPUP: StartCoroutine(PlayAnimationRoutine(ENUM_ANIMATION_STATE_TYPE.ONAIR)); break;
            case ENUM_ANIMATION_STATE_TYPE.ONAIR: break;
            case ENUM_ANIMATION_STATE_TYPE.JUMPDOWN: StartCoroutine(PlayAnimationRoutine(ENUM_ANIMATION_STATE_TYPE.RUN)); break;
            default: break;
        }

        yield break;
    }
}
