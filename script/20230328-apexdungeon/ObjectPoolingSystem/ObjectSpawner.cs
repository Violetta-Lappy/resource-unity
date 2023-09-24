using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float timerToSpawn = 5f;
    private float timeSinceSpawn;
    private ObjectPool objectPool;


    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= timerToSpawn)
        {
            GameObject newObject = objectPool.GetObject(prefab);
            newObject.transform.position = this.transform.position;
            timeSinceSpawn = 0f;
        }
    }
}
