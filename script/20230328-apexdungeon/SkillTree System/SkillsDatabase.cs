using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skilltree/Create Skill Database")]
public class SkillsDatabase : ScriptableObject
{
    public List<ShopSkillItem> attackDatabase = new List<ShopSkillItem>();
    public List<ShopSkillItem> defenseDatabase = new List<ShopSkillItem>();
    public List<ShopSkillItem> speedDatabase = new List<ShopSkillItem>();
}
