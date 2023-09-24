using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore {
    public class AIEnemy : MonoBehaviour {
        public enum ENUM_AIBEHAVIOR_STATE_TYPE {
            IDLE_WAIT,
            MOVE_RANDOM_IN_AREA,
        }        

        [SerializeField] private ENUM_AIBEHAVIOR_STATE_TYPE enum_aiBehaviorType;
        public float f_lenghtX = 5.0f;
        public float f_lenghtZ = 5.0f;
        [SerializeField] private Vector3 vec3_gameAreaMin;
        [SerializeField] private Vector3 vec3_gameAreaMax;
        [SerializeField] private Vector3 vec3_center;
        [SerializeField] private bool isCalculateOnce = false;
        [SerializeField] private Vector3 vec3_nextPosition;
        [SerializeField] private float f_waitTime = 10.0f;

        private void Start() {
            CalculateGameAreaBasedOnCurrentPosition();
            OnEnemyBehavior(enum_aiBehaviorType);
        }

        private void Update() { }

        public void OnEnemyBehavior(ENUM_AIBEHAVIOR_STATE_TYPE _type) {
            switch (_type) {
                case ENUM_AIBEHAVIOR_STATE_TYPE.IDLE_WAIT:
                    WaitIdle();
                    break;
                case ENUM_AIBEHAVIOR_STATE_TYPE.MOVE_RANDOM_IN_AREA:
                    Move(GetRandomLocationWithinBounds(), Random.Range(1.0f, 4.0f));
                    break;
                default: break;
            }
        }

        public void CalculateGameAreaBasedOnCurrentPosition() {
            if (isCalculateOnce) return;

            float minAreaX = this.transform.position.x - f_lenghtX;
            float minAreaZ = this.transform.position.z - f_lenghtZ;

            float maxAreaX = this.transform.position.x + f_lenghtX;
            float maxAreaZ = this.transform.position.z + f_lenghtZ;

            vec3_gameAreaMin = new Vector3(minAreaX, this.transform.position.y, minAreaZ);
            vec3_gameAreaMax = new Vector3(maxAreaX, this.transform.position.y, maxAreaZ);
            vec3_center = new Vector3((vec3_gameAreaMax.x + vec3_gameAreaMin.x) / 2, this.transform.position.y, (vec3_gameAreaMax.z + vec3_gameAreaMin.z) / 2);            

            isCalculateOnce = true;
        }

        public Vector3 GetRandomLocationWithinBounds() {
            Vector3 temp = Vector3.one;                        

            float x = Random.Range(vec3_gameAreaMin.x, vec3_gameAreaMax.x);
            float z = Random.Range(vec3_gameAreaMin.z, vec3_gameAreaMax.z);

            //Debug.Log("New Area " + new Vector3(maxAreaX, this.transform.position.y, maxAreaZ));

            temp = new Vector3(x, this.transform.position.y, z);
            return vec3_nextPosition = temp;
        }

        public void StartRandomBehavior() {
            int count = System.Enum.GetNames(typeof(ENUM_AIBEHAVIOR_STATE_TYPE)).Length;
            enum_aiBehaviorType = (ENUM_AIBEHAVIOR_STATE_TYPE)Random.Range(0, count);
            OnEnemyBehavior(enum_aiBehaviorType);
        }

        public void WaitIdle() => StartCoroutine(RoutineWait(Random.Range(1.0f, 5.0f)));
        public void Move(Vector3 _destination, float _time) => StartCoroutine(RoutineMove(_destination, _time));

        private System.Collections.IEnumerator RoutineWait(float _time) {
            f_waitTime = _time;
            yield return new WaitForSeconds(_time);
            OnEnemyBehavior(ENUM_AIBEHAVIOR_STATE_TYPE.MOVE_RANDOM_IN_AREA);
        }

        private System.Collections.IEnumerator RoutineMove(UnityEngine.Vector3 _destination, float _time) {

            f_waitTime = _time;

            UnityEngine.Vector3 startPosition = this.transform.position;

            bool isReachDest = false;

            float elapsedTime = 0f;

            //While loop for lerp between two destinations purpose
            while (isReachDest == false) {

                if (UnityEngine.Vector3.Distance(this.transform.position, _destination) < 0.01f) {
                    isReachDest = true; //confirm
                    this.transform.position = _destination; //set the position of this object equals to the destination                    

                    OnEnemyBehavior(ENUM_AIBEHAVIOR_STATE_TYPE.IDLE_WAIT);

                    break; //break-out-of-the-loop                
                }

                //Lerp between 0 and 1
                elapsedTime += UnityEngine.Time.deltaTime;
                float t = elapsedTime / _time;
                this.transform.position = UnityEngine.Vector3.Lerp(startPosition, _destination, t);
                yield return null; //Back to the start of while loop
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;            
            if (isCalculateOnce == false) Gizmos.DrawLine(new Vector3(this.transform.position.x - f_lenghtX, 1, this.transform.position.z - f_lenghtZ), new Vector3(this.transform.position.x + f_lenghtX, 1, this.transform.position.z + f_lenghtZ));
            else if(isCalculateOnce) Gizmos.DrawLine(vec3_gameAreaMin, vec3_gameAreaMax);
        }
    }
}


