using UnityEngine;

namespace VLGameProject.VLTagLayer {
    
    public enum ENUMTag {
        K_None = 0,
        K_GameWorldStatic,
        K_GameWorldDynamic,
        K_GamePawnPlayer,
        K_GamePawnThreat,
    }
    
    [CreateAssetMenu(fileName = "New Tag", menuName = "VLGameProject/TagLayer/New Tag")]
    public class SOTag : ScriptableObject { }
}
