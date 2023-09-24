using UnityEngine;

namespace VLGameProject.VLVisual {
    public enum ENUM_EASE {
        K_NONE = 0,
        K_LINEAR,
        K_SINE_IN,
        K_SINE_OUT,
        K_SINE_IN_OUT,
        K_QUAD_IN,
        K_QUAD_OUT,
        K_QUAD_IN_OUT,
        K_CUBIC_IN,
        K_CUBIC_OUT,
        K_CUBIC_IN_OUT,
        K_QUART_IN,
        K_QUART_OUT,
        K_QUART_IN_OUT,
        K_QUINT_IN,
        K_QUINT_OUT,
        K_QUINT_IN_OUT,
        K_EXPO_IN,
        K_EXPO_OUT,
        K_EXPO_IN_OUT,
        K_CIRCLE_IN,
        K_CIRCLE_OUT,
        K_CIRCLE_IN_OUT,
        K_ELASTIC_IN,
        K_ELASTIC_OUT,
        K_ELASTIC_IN_OUT,
        K_BACK_IN,
        K_BACK_OUT,
        K_BACK_IN_OUT,
        K_BOUNCE_IN,
        K_BOUNCE_OUT,
        K_BOUNCE_IN_OUT,
        K_FLASH,
        K_FLASH_IN,
        K_FLASH_OUT,
        K_FLASH_IN_OUT,
    }

    public abstract class SOABSEase : ScriptableObject {
        public abstract ENUM_EASE Get_Ease();
    }

    [CreateAssetMenu(fileName = "New Example", menuName = "VLGameProject/Ease/New Example")]
    public class Ease_Example : SOABSEase {
        public override ENUM_EASE Get_Ease() {
            return ENUM_EASE.K_NONE;
        }
    }
}
