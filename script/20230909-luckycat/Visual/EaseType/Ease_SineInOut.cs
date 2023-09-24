using UnityEngine;

namespace VLGameProject.VLVisual {
    [CreateAssetMenu(fileName = "New SineInOut", menuName = "VLGameProject/Ease/New SineInOut")]
    public class Ease_SineInOut : SOABSEase {
        public override ENUM_EASE Get_Ease() {
            return ENUM_EASE.K_SINE_IN_OUT;
        }
    }
}
