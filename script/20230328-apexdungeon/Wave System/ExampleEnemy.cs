using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 20/10/2021
Object(s) holding this script: EnemyExample,EnemyExample1,EnemyExample2
Summary: 
Destroy enemy (this gameobject) on mouse click
Increase the enemiesKilled in WaveSystem by one before destroy this gameObject
(when an enemy is killed)
***************************/

public class ExampleEnemy : MonoBehaviour
{
    public WaveSystem waveScript;

    //Test code
    private void OnMouseDown()
    {
        //increase the enemiesKilled in WaveSystem by one
        //waveScript.enemiesKilled++;

        Destroy(gameObject);
    }
}
