using UnityEngine;

namespace VLGameProject.VLVisual {
    [CreateAssetMenu(fileName = "New SineOut", menuName = "VLGameProject/Ease/New SineOut")]
    public class Ease_SineOut : SOABSEase {
        public override ENUM_EASE Get_Ease() {
            return ENUM_EASE.K_SINE_OUT;
        }
    }
}
