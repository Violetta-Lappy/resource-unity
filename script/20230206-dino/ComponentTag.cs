using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_OBJECT_TAG
{
    PLAYER,
    GROUND,
    OBSTACLE
}

public class ComponentTag : MonoBehaviour
{
    [SerializeField] private ENUM_OBJECT_TAG enum_objectTag;

    public ENUM_OBJECT_TAG GetTag() { return enum_objectTag; }
    public bool IsTag(ENUM_OBJECT_TAG compareTag) { return enum_objectTag == compareTag; }
}
