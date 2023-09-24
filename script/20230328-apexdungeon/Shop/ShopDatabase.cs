using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Database", menuName = "Shop/Shop Database")]
public class ShopDatabase : ScriptableObject
{
    public ShopItem[] itemDB;
    public ShopUpgradeItem[] upgradeDB;
}
