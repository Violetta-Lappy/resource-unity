using UnityEngine;

namespace VLGameProject.VLTagLayer {

    public enum ENUMLayer {
        K_None = 0,
        K_CameraNotRender,
        K_Gui,
    }

    [CreateAssetMenu(fileName = "New Layer", menuName = "VLGameProject/TagLayer/New Layer")]
    public class SOLayer : ScriptableObject { }
}
