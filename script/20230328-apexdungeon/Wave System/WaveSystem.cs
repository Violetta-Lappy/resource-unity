using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 20/10/2021
Object(s) holding this script: Wave
Summary: 
Instantiate a certain number of random enemies without overlapsing at certain spots
After all enemies in a wave killed, start another one until it reaches the
maximum number of waves
***************************/

public class WaveSystem : MonoBehaviour
{
    private float xPos;                     //x coordinate to spawn
    private float zPos;                     //z coordinate to spawn
    public Transform yPos;                  //y coordinate to spawn
    public Transform xMinPos;               // coordinate range to spawn
    public Transform xMaxPos;               // coordinate range to spawn
    public Transform zMinPos;               // coordinate range to spawn
    public Transform zMaxPos;               // coordinate range to spawn
    private int enemyCount;                 //the number of enemies spawned
    public int enemiesKilled = 0;           //the number of enemies killed
    public int minEnemyNum = 2;             //maximum number of enemies to spawn in a wave
    public int maxEnemyNum = 6;             //maximum number of enemies to spawn in a wave
    public int spawnAmount;                 //number of enemies to spawn
    public LayerMask enemyMask;             //enemy gameobeject's layer mask
    private int spawnedWave = 0;            //number of waves have been spawned
    public int maxWave = 4;                 //maximum number of waves to spawn
    public float minSpawnYield = 0.2f;      //minimum amount of time to wait to spawn the next enemy
    public float maxSpawnYield = 1f;        //maximum amount of time to wait to spawn the next enemy
    public bool outOfWaves = false;

    int maxIterations = 50;
    int curIte;
    public DoorBlockTrigger[] triggers;

    bool enterRoom;
    
    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        triggers = transform.parent.GetComponentsInChildren<DoorBlockTrigger>();

    }

    /// <summary>
    /// Lock room
    /// </summary>
    public void LockRoom()
    {
        enterRoom = true;
        foreach (var trigger in triggers)
        {
            trigger.EnableBlock();
        }
    }

    /// <summary>
    /// Update per frame.
    /// </summary>
    void Update()
    {
        if (enterRoom && !outOfWaves)
        {
            if (spawnedWave < MasterGameSystem.Instance.databaseMain.numOfWaves)
            {
                //if all enemies in a wave were killed
                if (enemiesKilled == spawnAmount)
                {
                    //reset enemiesKilled and enemyCount to 0
                    enemiesKilled = 0;
                    enemyCount = 0;

                    //get a random of number of enemies to spawn in next wave
                    int randEnemyNumber = Random.Range(MasterGameSystem.Instance.databaseMain.minPerWave, MasterGameSystem.Instance.databaseMain.maxPerWave);

                    //call SpawnEnemiesRoutine() below to start another wave
                    StartCoroutine(SpawnEnemiesRoutine(randEnemyNumber));
                }
            }
            else // if the maximum of waves has been reached
            {
                // Debug.Log("No more wave!");

                //if all enemies in a wave were killed
                if (enemiesKilled == spawnAmount)
                {
                    outOfWaves = true;
                    foreach (var trigger in triggers)
                    {
                        trigger.DisableBlock();
                        RoomClearedNotification.instance.PushNotification();
                    }
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void RegisterKilled()
    {
        enemiesKilled++;
    }

    //Set spawnAmount equal to value passed in
    //Instantiate a certain number of enemies at random positions
    //within a range without overlapsing existing objects
    IEnumerator SpawnEnemiesRoutine(int maxToSpawn, float waitForNextWave = 0.4f)
    {
        spawnAmount = maxToSpawn;
        spawnedWave++;

        //Debug.Log("wave" + spawnedWave);

        while (enemyCount < maxToSpawn)
        {

            //get random x and z within a certain range
            xPos = Random.Range(xMinPos.position.x, xMaxPos.position.x);
            zPos = Random.Range(zMinPos.position.z, zMaxPos.position.z);
            Vector3 spawnPos = new Vector3(xPos, yPos.position.y, zPos);

            //check if the position to spawn an enemy already has an object
            if (Physics.CheckSphere(spawnPos, 1.0f, enemyMask) == false)
            {

                RaycastHit hit;

                if (Physics.Raycast(spawnPos, Vector3.down, out hit, 5f))
                {
                   if(hit.collider.gameObject.layer == 7)
                    {
                        //get a random enemy from array to spawn
                        int randEnemyIndex = Random.Range(0, MasterGameSystem.Instance.databaseMain.enemyDB.Length);

                        //instantiate an enemy
                        GameObject enemySpawned = Instantiate(MasterGameSystem.Instance.databaseMain.enemyDB[randEnemyIndex], spawnPos, Quaternion.identity);

                        enemySpawned.GetComponent<EnemyHealth>().spawner = this;

                        //increase the number of enemies spawned in this wave by one
                        enemyCount += 1;

                        //get a random time to wait for next spawn
                        float randSpawnYield = Random.Range(minSpawnYield, maxSpawnYield);

                        /*
                        curIte++;

                        if(curIte >= maxIterations)
                        {
                            yield break;
                        } 
                         */

                        yield return new WaitForSeconds(randSpawnYield);
                    }
                }





            }
        }
    }
}
