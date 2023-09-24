using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skilltree : MonoBehaviour
{    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}

[System.Serializable]
public class PlayerAttribute
{        
    public string name;            
    public CharacterStat stat;
    public float realValue;    
}

public enum COST_TYPE
{
    ATTACK_RUNE,
    DEFENCE_RUNE,
    SPEED_RUNE
}

public enum SKILL_NAME
{
    NONE,
    Dash,
    Defence,
    Time_Stop,    
}

public enum STAT_NAME
{
    NONE,
    Upgrade_Health,
    Upgrade_Stamina,
    Upgrade_Attack,
    Upgrade_Defense,
    Upgrade_Speed
}
