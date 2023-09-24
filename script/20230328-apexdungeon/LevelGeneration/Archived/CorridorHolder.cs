using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CorridorDirection
{
    top,bot,left,right
}

public class CorridorHolder : MonoBehaviour
{
    public GameObject topGO,botGO,leftGO,rightGO;
    
    public void EnableGO(GameObject GO)
    {
        GO.SetActive(true);
    }

    public void DisableGO(GameObject GO)
    {
        GO.SetActive(false);
    }
}
