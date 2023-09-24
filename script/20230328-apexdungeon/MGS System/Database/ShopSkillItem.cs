using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill Shop Item", menuName = "Project/Database/03. Create a Skill Shop Item")]
public class ShopSkillItem : ScriptableObject
{
    [Header("Info")]
    public Sprite icon;        
    public string description;

    [Header("Skill Info")]
    //public SKILL_NAME skillName;
    public string skillName;

    //[Header("Stat Info")]
    //public STAT_NAME statName;
    //[Range(0, 10)] public int statIncreaseValue;
    
    [Header("Cost Info")]    
    public COST_TYPE costType;
    [Range(0, 10)] public int cost;
}
