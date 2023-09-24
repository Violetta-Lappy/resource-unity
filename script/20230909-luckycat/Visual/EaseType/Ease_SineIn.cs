using UnityEngine;

namespace VLGameProject.VLVisual {
    [CreateAssetMenu(fileName = "New SineIn", menuName = "VLGameProject/Ease/New SineIn")]
    public class Ease_SineIn : SOABSEase {
        public override ENUM_EASE Get_Ease() {
            return ENUM_EASE.K_SINE_IN;
        }
    }
}
