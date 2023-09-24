using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 20/10/2021
Object(s) holding this script: Companion
Summary: 
Handles Companion's logic
Follow Player
Attack Enemy When In Range
*****************************************************************************************************************************/
public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent companion;

    public Transform player;

    public GameObject[] enemy;

    private float distance;
    private Vector3 enemyPos;
    private float currentDistance;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        AccompanyPlayer();
    }

    //Called in Update()
    //Move towards and follow player
    void AccompanyPlayer()
    {
        companion.SetDestination(player.position);
    }



    /*private GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        distance = Mathf.Infinity;
        enemyPos = transform.position;

        foreach (GameObject enemyInRange in enemy)
        {
            Vector3 diff = enemyInRange.transform.position - enemyPos;
            currentDistance = diff.sqrMagnitude;

            if (currentDistance < distance)
            {
                closest = enemyInRange;
                distance = currentDistance;
            }
        }

        return closest;
    }*/

}
