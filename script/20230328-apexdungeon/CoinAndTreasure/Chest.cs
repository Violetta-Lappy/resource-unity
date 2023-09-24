using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 25/10/2021
Object(s) holding this script: Chest
Summary: 
Spawn a random number of coins (only after all waves are cleaned)
***************************/

public class Chest : MonoBehaviour
{

    public float force = 3f; //force add to coins after spawn them
    public GameObject coinPrefab; // coin gameobject
    public float randXRange = 100f; //range x to add force
    public float randMinYRange = 50f; //minimum range y to add force
    public float randMaxYRange = 150f; //maximum range y to add force
    public float randZRange = 100f; //range z to add force
    public float spawnDuration = 0.2f; //maximum time to wait to spawn next coin
    private WaveSystem waveScript; //wave script reference
    public int minCoinToSpawn = 3; //minimum number of coins ro spawn
    public int maxCoinToSpawn = 6; //maximum number of coins to spawn

    // Start is called before the first frame update
    void Start()
    {
        waveScript = GameObject.Find("Wave").GetComponent<WaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //test code
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (waveScript.outOfWaves == true)
            {
                SpawnCoin();
            }
            else
            {
                Debug.Log("Still have enemy");
            }
        }
    }

    //Call SpawnCoinRoutine() below
    void SpawnCoin()
    {
        StartCoroutine(SpawnCoinRoutine());
    }

    //Called by SpawnCoin() above
    //get a random number of coins to spawn
    //spawn coins and add force to them
    IEnumerator SpawnCoinRoutine()
    {
        int randCoin = Random.Range(minCoinToSpawn, maxCoinToSpawn);
        Debug.Log("Spawn " + randCoin + " coins");

        for (int i = 0; i < randCoin; i++)
        {
            GameObject coinSpawned = Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z), Quaternion.identity);

            coinSpawned.GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-randXRange, randXRange) * force, Random.Range(randMinYRange, randMaxYRange) * force, Random.Range(-randZRange, randZRange) * force);
            yield return new WaitForSeconds(Random.Range(0f, spawnDuration));
        }
    }
}
