using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/****************************************************************************************************************************
Author: Duong Duc Nguyen
Date Made: 17/11/2021
Object(s) holding this script: Companion
Summary: 

*****************************************************************************************************************************/

public class Companion : MonoBehaviour
{
    private NavMeshAgent companion;

    private Transform targetEnemy;
    private Transform player;

    public float accompanyDistance; //Distance between companion and player when player being accompanied
    public float scanRadius; //Radius of the shpere
    public float roamingDistance; //Company will return to player when it gets this far
    public float attackingRange;
    public float damage;
    public float attackDelay;

    private bool isAttacking; //Companion is currently attacking
    private bool isReturning; //Companion is currently returning to player
    private bool detected;

    

    private void Start()
    {
        companion = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Transform>();;
    }

    private void Update()
    {
        FollowPlayer();
        DetectEnemies(transform.position, scanRadius);
        AttackEnemy();
        ReturnToPlayer();
    }
    
    //Moving toward player
    //Called in Update()
    private void FollowPlayer()
    {
        //When player is not near player & is not attacking
        if (OutAccompanyRange(player.position, transform.position) && !isAttacking)
        {
            companion.SetDestination(player.position - new Vector3(1, 0 ,1));
        }
        if (!OutAccompanyRange(player.position, transform.position))
        {
            isReturning = false;
        }
    }

    //Detect whether companion is in accompany range
    //Called by FollowPlayer()
    bool OutAccompanyRange(Vector3 playerPos, Vector3 companionPos)
    {
        if (Vector3.Distance(playerPos, companionPos) > accompanyDistance)
        return true;
        else
        return false;
    }

    //Detect enemies around companion
    //Called in Update()
    private void DetectEnemies(Vector3 center, float radius)
    {
        Collider[] hitObjects = Physics.OverlapSphere(center, radius);
    
        foreach (var hitObject in hitObjects)
        {
            if (hitObject.tag == "Enemy" && !detected && !isReturning)
            {
                detected = true;
                targetEnemy = hitObject.transform;
            }
        }
    }

    //Called by DetectEnemies()
    private void AttackEnemy()
    {
        //When player is not in both attacking or returning state
        if (detected && targetEnemy)
        {
            companion.SetDestination(targetEnemy.position - new Vector3(1, 0 ,1));
            StartCoroutine("DealDamageOnEnemy");

            //Debug.Log("Enemy at " + targetEnemy.position);
        }
    }

    //Called by AttackEnemy()
    IEnumerator DealDamageOnEnemy()
    {
        GeneralHealth generalHealth;
        PopUpDamage popUpDamage;

        if (targetEnemy)
        {
            if (targetEnemy.GetComponent<GeneralHealth>() && targetEnemy.GetComponent<PopUpDamage>())
            {
                generalHealth = targetEnemy.GetComponent<GeneralHealth>();
                popUpDamage = targetEnemy.GetComponent<PopUpDamage>();

                if (Vector3.Distance(targetEnemy.position, transform.position) <= attackingRange && generalHealth.currentHealth > 0 && !isAttacking)
                {
                    isAttacking = true;

                    for (int i = 0; i < 100; i++)
                    {
                        generalHealth.TakeDamage(damage);
                        popUpDamage.FloatingDamage(damage);
                        Debug.Log("Attacking");
                        if (!targetEnemy) break;
                        yield return new WaitForSeconds(attackDelay);
                    }
                }
            }
        }
    }

    //Called in Update()
    private void ReturnToPlayer()
    {
        if (Vector3.Distance(player.position, transform.position) > roamingDistance)
        {
            isAttacking = false;
            isReturning = true;
            detected = false;
            targetEnemy = null;
        }
    }

    //Make Overlap Sphere visible
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere (transform.position, scanRadius);
    }
}