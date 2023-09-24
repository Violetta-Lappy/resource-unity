using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] private Transform spawnPos;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnObj = Instantiate(objToSpawn, spawnPos.position, Quaternion.identity);
        }
    }


}
