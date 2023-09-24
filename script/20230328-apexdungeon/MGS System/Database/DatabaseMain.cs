using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//CAN ONLY CREATE ONCE PER PROJECT
[CreateAssetMenu(fileName = "Main Database", menuName = "Project/Database/00 - Create a Main Database")]
public class DatabaseMain : ScriptableObject
{
    public GameObject[] enemyDB;
    [FormerlySerializedAs("minEnemyWave")] public int minPerWave = 3;
    [FormerlySerializedAs("maxEnemyWave")] public int maxPerWave = 6;
    public int numOfWaves = 3;
    public ShopItem[] shopItemDB;
    public ShopSkillItem[] shopSkillDB;
    public ShopUpgradeItem[] shopUpgradeDB;
    public ShopAttachItem[] shopAttachDB;
}
