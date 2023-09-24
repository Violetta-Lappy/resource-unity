using UnityEngine;

namespace VLGameProject.VLGameProgram {
    public abstract class GameProgramObject : MonoBehaviour {
        //TODO - Add Component Tag
        [Header("GameProgramObject")]
        public GameProgramManager m_gameProgram;
        public GameProgramManager Get_GameProgram() { return m_gameProgram; }
        public virtual void Awake() => m_gameProgram = GameProgramManager.Instance(); //get the instance, set the reference 
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public void GPO_ScheduleUpdate(float arg_tick) { 

            //Reset time

            ScheduleUpdate(arg_tick); 

            //return back
        }
        public virtual void ScheduleUpdate(float arg_tick) { }
    }
}