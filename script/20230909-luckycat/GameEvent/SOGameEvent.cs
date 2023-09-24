using UnityEngine;

namespace VLGameProject.VLGameEvent {
    public class SOGameEvent : ScriptableObject {
        public virtual void GameEvent_Start() { }
        public virtual void GameEvent_Update() { }
        public virtual void GameEvent_End() { }
    }
}

