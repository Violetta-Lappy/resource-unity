using UnityEngine;

namespace VLGameProject.VLVisual {
    [CreateAssetMenu(fileName = "New None", menuName = "VLGameProject/Ease/New None")]
    public class Ease_None : SOABSEase {
        public override ENUM_EASE Get_Ease() {
            return ENUM_EASE.K_NONE;
        }
    }
}
