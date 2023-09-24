using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 20/10/2021
Object(s) holding this script: Enemy
Summary: 
Handles Enemy's logic
Patroling
Following Player
Attack Player
*****************************************************************************************************************************/

public class BaseEnemy : MonoBehaviour
{
    //Variables for patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Variables for attacking 
    public float timeBtwAttacks;
    bool attacked;
    public GameObject projectile;
    public GameObject shootingPoint;

    //Variables to check whether or not able to see and attack player
    public float losRange;
    public float attackRange;
    public bool playerInLOS;
    public bool playerInAttackRange;

    public NavMeshAgent enemy;
    public Transform player;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //Check for player either in light of sight and within attack range
        playerInLOS = Physics.CheckSphere(transform.position, losRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        EnemyLogic();
    }

    //Self-explanatory 
    //Called by Update
    void EnemyLogic()
    {
        if (!playerInLOS && !playerInAttackRange)
        {
            Patrol();
        }
        else if (playerInLOS && !playerInAttackRange)
        {
            FollowPlayer();
            //Debug.Log("Player in line of sight range");
        }
        else if (playerInLOS && playerInAttackRange)
        {
            AttackPlayer();
            //Debug.Log("Player in attack range");
        }
    }

    //Called by EnemyLogic() above if player is not in sight nor in attack range
    void Patrol()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            enemy.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1.0f)
        {
            walkPointSet = false;
        }
    }

    //Called by Patrol() in order to continously find space to navigate 
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2.0f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    //Called by EnemyLogic() above if player is in sight but not in attack range
    void FollowPlayer()
    {
        enemy.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        enemy.SetDestination(transform.position);

        transform.LookAt(player);

        if (!attacked)
        {
            Rigidbody rigidbody = Instantiate(projectile, shootingPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward * 30.0f, ForceMode.Impulse);
            rigidbody.GetComponent<EnemyBulletBehavior>().rotateDir = transform.localRotation.eulerAngles.y;
            rigidbody.AddForce(transform.up * 8.0f, ForceMode.Impulse);

            attacked = true;
            Invoke(nameof(ResetAttack), timeBtwAttacks);
        }
    }

    //Called by AttackPlayer() after perform an attack
    void ResetAttack()
    {
        attacked = false;
    }

    //Create sphere in order to help see where the ranges are
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, losRange);
    }
}
