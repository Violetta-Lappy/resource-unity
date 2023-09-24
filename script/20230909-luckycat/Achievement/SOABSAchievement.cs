using UnityEngine;

namespace VLGameProject.VLAchievement {
    //Check to see achievemen by FTL game
    public abstract class SOABSAchievement : ScriptableObject {
        public abstract void Achievement_Success();
        public abstract void Achievement_Fail();
        public abstract void Achievement_InProgress();
    }

    public class AchievementKillCountReach : SOABSAchievement {
        public int i32_killCountGoal;

        public override void Achievement_Fail() {
            throw new System.NotImplementedException();
        }

        public override void Achievement_InProgress() {
            throw new System.NotImplementedException();
        }

        public override void Achievement_Success() {
            throw new System.NotImplementedException();
        }
    }
}
