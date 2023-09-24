using UnityEngine;

namespace VLGameProject.VLVisual {
    [CreateAssetMenu(fileName = "New Linear", menuName = "VLGameProject/Ease/New Linear")]
    public class Ease_Linear : SOABSEase {
        public override ENUM_EASE Get_Ease() {
            return ENUM_EASE.K_LINEAR;
        }
    }
}
