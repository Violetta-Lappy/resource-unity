using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameMode;

namespace VLGameProject.VLGameDatabase {
    [CreateAssetMenu(fileName = "New GameDatabase-Example", menuName = "VLGameProject/GameDatabase/New GameDatabase-Example")]
    public class GameDatabaseExample : SOABSGameDatabase {
        public GameDatabaseProgram m_gameDatabaseProgram;
        public List<SOABSGameMode> list_m_gameMode;        

        private void Reset() {
            
        }
    }
}
