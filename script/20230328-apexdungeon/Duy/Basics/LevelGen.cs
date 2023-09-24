using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class LevelGen : MonoBehaviour
{
    public int width = 10;
    public int height = 10;

    public GameObject obj;

    public NavMeshSurface surfaces;

    // Start is called before the first frame update
    void Start()
    {
        GenLevel();

        surfaces.BuildNavMesh();
    }

    void GenLevel()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (Random.value > 0.7f)
                {
                    Vector3 pos = new Vector3(i - width / 2.0f, 1.0f, j - height / 2.0f);
                    Instantiate(obj, pos, Quaternion.identity, transform);
                }
            }
        }
    }
}
