using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBakeRuntime : MonoBehaviour
{
    [SerializeField] NavMeshSurface[] navMeshSurfaces;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }
}
