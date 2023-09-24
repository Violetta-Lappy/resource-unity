using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootEnemy : MonoBehaviour
{

    private Loot lootScript;

    // Start is called before the first frame update
    void Start()
    {
        lootScript = GameObject.Find("Loot").GetComponent<Loot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        lootScript.LootRandom(transform.position);
        Destroy(gameObject);
    }


}
