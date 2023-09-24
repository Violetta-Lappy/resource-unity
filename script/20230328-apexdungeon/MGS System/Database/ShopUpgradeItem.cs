using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Name", menuName = "Project/Database/04. Create an upgrade shop item")]
public class ShopUpgradeItem : ScriptableObject
{
    public int id;
    public string upgradeName;
    public Sprite icon;
    public float upgradePercent;    
    public int cost;    
}
