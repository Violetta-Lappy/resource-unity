public class GUIElementObject : UnityEngine.MonoBehaviour {
    public ENUM_GUIELEMENT_OBJECT_TYPE type;
    public bool IsType(ENUM_GUIELEMENT_OBJECT_TYPE _type) { return _type == type; }
    public bool IsActive() { return isActiveAndEnabled; }
}
