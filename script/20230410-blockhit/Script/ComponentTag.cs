using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_TAG_TYPE {
    PLAYER_HUB,    
    ENEMY,
    OBSTACLE,
    GROUND_CHECK,
    PLATFORM    
}

public class ComponentTag : MonoBehaviour {
    [SerializeField] private ENUM_TAG_TYPE enum_tagType;
    public bool IsType(ENUM_TAG_TYPE _type) { return _type == enum_tagType; }
    public ENUM_TAG_TYPE GetTagType() { return enum_tagType; }
}
