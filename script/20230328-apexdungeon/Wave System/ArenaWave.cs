using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWave : MonoBehaviour
{
    public GameObject[] enemy; //enemy to spawn
    public Transform[] spawnSpots; //spots to spawn enemy at
    private int enemyCount; //the number of enemies spawned
    public int enemiesKilled = 0; //the number of enemies killed
    public int minEnemyNum = 2; //maximum number of enemies to spawn in a wave
    public int maxEnemyNum = 6; //maximum number of enemies to spawn in a wave
    public int spawnAmount; //number of enemies to spawn
    public LayerMask enemyMask; //enemy gameobeject's layer mask
    private int spawnedWave = 0; //number of waves have been spawned
    public int maxWave = 4; //maximum number of waves to spawn
    public float minSpawnYield = 0.2f; //minimum amount of time to wait to spawn the next enemy
    public float maxSpawnYield = 1f; //maximum amount of time to wait to spawn the next enemy
    public bool outOfWaves = false;


    // Update is called once per frame
    void Update()
    {
        if (spawnedWave < maxWave)
        {
            //if all enemies in a wave were killed
            if (enemiesKilled == spawnAmount)
            {
                //reset enemiesKilled and enemyCount to 0
                enemiesKilled = 0;
                enemyCount = 0;

                //get a random of number of enemies to spawn in next wave
                int randEnemyNumber = Random.Range(minEnemyNum, maxEnemyNum);

                //call SpawnEnemiesRoutine() below to start another wave
                StartCoroutine(SpawnEnemiesRoutine(randEnemyNumber));
            }
        }
        else // if the maximum of waves has been reached
        {
            Debug.Log("No more wave!");

            //if all enemies in a wave were killed
            if (enemiesKilled == spawnAmount)
            {
                outOfWaves = true;
            }
        }
    }
   

    //Set spawnAmount equal to value passed in
    //Instantiate a certain number of enemies at random positions
    //within a range without overlapsing existing objects
    IEnumerator SpawnEnemiesRoutine(int maxToSpawn, float waitForNextWave = 0.4f)
    {
        spawnAmount = maxToSpawn;
        spawnedWave++;

        Debug.Log("wave" + spawnedWave);

        while (enemyCount < maxToSpawn)
        {
            //get a random spot from array to spawn an enemy at
            int randSpotIndex = Random.Range(0, spawnSpots.Length);

            //get the position of that spot
            Vector3 randomSpot = new Vector3(spawnSpots[randSpotIndex].transform.position.x, spawnSpots[randSpotIndex].transform.position.y, spawnSpots[randSpotIndex].transform.position.z);

            //check if the position to spawn an enemy already has an object
            if (Physics.CheckBox(randomSpot, new Vector3(1, 1, 1), Quaternion.identity, enemyMask) == false)
            {
                //get a random enemy from array to spawn
                int randEnemyIndex = Random.Range(0, enemy.Length);

                //instantiate an enemy
                GameObject enemySpawned = Instantiate(enemy[randEnemyIndex], randomSpot, Quaternion.identity);

                //increase the number of enemies spawned in this wave by one
                enemyCount += 1;

                //get a random time to wait for next spawn
                float randSpawnYield = Random.Range(minSpawnYield, maxToSpawn);

                yield return new WaitForSeconds(randSpawnYield);
            }
        }
    }
}
