using UltEvents;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGameBlueprint {
    public abstract class ABSGameBlueprint : GameProgramObject {
        //Event
        [Header("Event")]
        public UltEvent On_GameBlueprint_Awake;
        public UltEvent On_GameBlueprint_Start;
        public UltEvent On_GameBlueprint_Update;
        public UltEvent On_GameBlueprint_FixedUpdate;

        public override void Awake() {
            base.Awake();
            On_GameBlueprint_Awake?.Invoke();
            GameBlueprint_Awake();
        }

        public override void Start() {
            base.Start();
            GameBlueprint_Start();
            On_GameBlueprint_Start?.Invoke();            
        }

        public override void Update() {
            base.Update();
            GameBlueprint_Update();
            On_GameBlueprint_Update?.Invoke();            
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            GameBlueprint_FixedUpdate();
            On_GameBlueprint_FixedUpdate?.Invoke();            
        }

        //Function    
        public abstract void GameBlueprint_Awake();
        public abstract void GameBlueprint_Start();
        public abstract void GameBlueprint_Update();
        public abstract void GameBlueprint_FixedUpdate();
    }
}
