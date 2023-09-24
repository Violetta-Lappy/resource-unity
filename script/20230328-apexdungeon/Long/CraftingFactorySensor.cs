using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingFactorySensor : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        //Call and transfer input to Crafting Factory
        transform.parent.GetComponent<CraftingFactory>().InputRecipe(collider.gameObject);
    }
}
