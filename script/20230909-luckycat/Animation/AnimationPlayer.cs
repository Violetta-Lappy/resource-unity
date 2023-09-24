/*
Copyright 2023 hoanglongplanner 

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.

You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using VLGameProject.Tool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.Animation {
    //Character Pawn Animation
    public enum ENUM_ANIMATION_STATE_TYPE {
        K_IDLE,
        K_WALK,
        K_RUN,
        K_CROUCH,
        K_JUMP_UP,
        K_ON_AIR,
        K_JUMP_DOWN,
        K_ATTACK_MELEE_HOLD,
        K_ATTACK_MELEE_RELEASE,
        K_ATTACK_RANGE_HOLD,
        K_ATTACK_RANGE_RELEASE,
        K_DEATH
    }

    //Weapon Animation
    public enum ENUM_WEAPON_ANIMATION_STATE_TYPE {
        K_IDLE,
        K_HOLD,
        K_RELEASE,
    }

    [RequireComponent(typeof(Animator))]
    public class AnimationPlayer : MonoBehaviour {

        [SerializeField] private Animator m_animator;
        [SerializeField] private ENUM_ANIMATION_STATE_TYPE enum_currentAnim;
        [SerializeField] private ENUM_ANIMATION_STATE_TYPE enum_previousAnim;
        [SerializeField] private bool isAnimationDone = false;
        [SerializeField] private float f_animTime;

        private void Start() {
            m_animator = GetComponent<Animator>().IsNull(this);
            PlayAnimation(ENUM_ANIMATION_STATE_TYPE.K_IDLE);
        }

        public string GetAnimationName(ENUM_ANIMATION_STATE_TYPE type) {
            switch (type) {
                case ENUM_ANIMATION_STATE_TYPE.K_IDLE: return "IDLE";
                case ENUM_ANIMATION_STATE_TYPE.K_WALK: return "WALK";
                default: Debug.Log("NO ANIMATION NAME OF THAT TYPE !!"); return "NONE";
            }
        }

        public bool IsAnimationDone() { return isAnimationDone; }

        public bool IsTypeAnimCurrent(ENUM_ANIMATION_STATE_TYPE _type) { return enum_currentAnim == _type; }

        public void PlayAnimation(ENUM_ANIMATION_STATE_TYPE _type) {
            if (IsAnimationDone())
                StartCoroutine(RoutineAnimation(_type));
        }

        public void PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE type) {
            StopAllCoroutines();

            enum_previousAnim = type;
            enum_currentAnim = enum_previousAnim;

            StartCoroutine(RoutineAnimation(enum_currentAnim));
        }

        public void ResetAnimation() => PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE.K_IDLE);

        public void StopAnimation() => m_animator.StopPlayback();

        private IEnumerator RoutineAnimation(ENUM_ANIMATION_STATE_TYPE _type) {
            if (enum_currentAnim == enum_previousAnim) yield break;

            enum_previousAnim = enum_currentAnim; //Archive previous animation state
            enum_currentAnim = _type; //Change to new animation name

            isAnimationDone = false;

            m_animator.Play(GetAnimationName(enum_currentAnim));

            f_animTime = m_animator.GetCurrentAnimatorStateInfo(0).length; //get wait time

            yield return new WaitForSeconds(f_animTime); //wait

            isAnimationDone = true;

            yield return OnAnimationDone(enum_currentAnim); //recursion-continulous-loop
        }

        private IEnumerator OnAnimationDone(ENUM_ANIMATION_STATE_TYPE type) {
            switch (type) {
                case ENUM_ANIMATION_STATE_TYPE.K_IDLE: StartCoroutine(RoutineAnimation(ENUM_ANIMATION_STATE_TYPE.K_IDLE)); break;
                default: break;
            }
            yield break;
        }
    }
}
