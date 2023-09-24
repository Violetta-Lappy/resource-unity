using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryObstacles : SingletonBlank<FactoryObstacles>
{
    [System.Serializable]
    public struct SpawnableObstacle
    {
        public GameObject prefab;
        public Vector3 offsets;

        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObstacle[] sz_obstaclesToSpawn;

    public float f_minSpawnRate;
    public float f_maxSpawnRate;

    private void Start()
    {
        f_minSpawnRate = ProjectConstants.K_SPAWNRATE_RANGE[0];
        f_maxSpawnRate = ProjectConstants.K_SPAWNRATE_RANGE[1];
    }

    private void OnEnable()
    {
        Invoke(nameof(EventSpawn), Random.Range(f_minSpawnRate, f_maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void EventSpawn()
    {
        float spawnRNGsus = Random.value;

        foreach(SpawnableObstacle obj in sz_obstaclesToSpawn)
        {
            if (spawnRNGsus < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position + obj.offsets;
                break;
            }

            spawnRNGsus -= obj.spawnChance;
        }

        Invoke(nameof(EventSpawn), Random.Range(f_minSpawnRate, f_maxSpawnRate));
    }
}
