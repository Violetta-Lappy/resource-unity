using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Item", menuName = "Project/Database/02. Create a Shop Item")]
public class ShopItem : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite icon;
    public int cost;
    public GameObject outputPrefab;
}
