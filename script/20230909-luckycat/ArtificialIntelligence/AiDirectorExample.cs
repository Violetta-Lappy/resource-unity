using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLAI {
    public class AiDirectorExample : ABSAiDirector {
        public enum ENUM_AIDIRECTOR_PRESET {
            //Preset that affect Behavior Tree and FSM Type
            K_NONE,
            K_AGRESSIVE,
            K_STATEGY,
        }

        public enum ENUM_AI_CONDITION {
            K_IS_WAITTIME_EXCEED,
            K_IS_ANIMATION_DONE,
            //For Opponent Bot
            K_IS_PLAYER_IN_LOS,
            K_IS_PLAYER_IN_ATTACKMELEE_DISTANCE,
            K_IS_PLAYER_IN_ATTACKRANGED_DISTANCE,
            //For Player Bot
            K_IS_OPPONENT_IN_LOS,
            K_IS_OPPONENT_IN_ATTACKMELEE_DISTANCE,
            K_IS_OPPONENT_IN_ATTACKRANGED_DISTANCE,
        }

        public bool IsAiCondition(ENUM_AI_CONDITION arg_type) {
            switch (arg_type) {
                case ENUM_AI_CONDITION.K_IS_WAITTIME_EXCEED: return isWaitTimeExceed;
                case ENUM_AI_CONDITION.K_IS_ANIMATION_DONE: return isAnimationDone;
                case ENUM_AI_CONDITION.K_IS_PLAYER_IN_LOS: return isPlayerInLOS;
                case ENUM_AI_CONDITION.K_IS_PLAYER_IN_ATTACKMELEE_DISTANCE: return isPlayerInAttackMeleeDistance;
                case ENUM_AI_CONDITION.K_IS_PLAYER_IN_ATTACKRANGED_DISTANCE: return isPlayerInAttackRangedDistance;
                case ENUM_AI_CONDITION.K_IS_OPPONENT_IN_LOS: return isOpponentInLOS;
                case ENUM_AI_CONDITION.K_IS_OPPONENT_IN_ATTACKMELEE_DISTANCE: return isOpponentInAttackMeleeDistance;
                case ENUM_AI_CONDITION.K_IS_OPPONENT_IN_ATTACKRANGED_DISTANCE: return isOpponentInAttackRangedDistance;
                default:
                    Debug.Log("Return ERROR");
                    return false;
            }
        }

        public void Set_IsAiCondition(ENUM_AI_CONDITION arg_type, bool arg_status) {
            switch (arg_type) {
                case ENUM_AI_CONDITION.K_IS_PLAYER_IN_LOS: break;
                case ENUM_AI_CONDITION.K_IS_PLAYER_IN_ATTACKMELEE_DISTANCE: break;
                default: break;
            }
        }

        public Vector3 vec3_playerPos;
        public Vector3 Get_PlayerPos() { return vec3_playerPos; }

        public float f_waitTime;
        public float Get_WaitTime() { return f_waitTime; }

        public bool isWaitTimeExceed;
        public bool isAnimationDone;
        public bool isPlayerInLOS;
        public bool isPlayerInAttackMeleeDistance;
        public bool isPlayerInAttackRangedDistance;
        public bool isOpponentInLOS;
        public bool isOpponentInAttackMeleeDistance;
        public bool isOpponentInAttackRangedDistance;

        public override void AiDirector_Awake() {
            Debug.Log($"No assigned {nameof(vec3_playerPos)}, unable to track {nameof(vec3_playerPos)}");
        }
        public override void AiDirector_Start() { }
        public override void AiDirector_Update() { }
    }
}

