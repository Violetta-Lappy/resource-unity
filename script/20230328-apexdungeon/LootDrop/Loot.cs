using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public List<GameObject> items;
    public int[] posibility ;

    public int total;
    public int randNum;
    public GameObject ItemToSpawn;

    private void Start()
    {
        foreach( int item in posibility)
        {
            //get total weight
            total += item;
        }

    }

    public void LootRandom(Vector3 positionToSpawn)
    {
        randNum = Random.Range(0, total);

        for (int i = 0; i < posibility.Length; i++){
            if(randNum <= posibility[i])
            {
                ItemToSpawn = items[i];

                //Spawn 
                GameObject spawnedItem = Instantiate(ItemToSpawn, positionToSpawn, Quaternion.identity);
                return;
            }
            else
            {
                randNum -= posibility[i];
            }
        }
    }
}
