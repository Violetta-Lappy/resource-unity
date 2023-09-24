using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using TMPro;

/****************************************************************************************************************************
Author: Pham Cong Duy + Long Revision
Date Made: 20/10/2021
Object(s) holding this script: Enemy
Summary: 
Use in conjunction with FSM
Handles Enemy's logic
Patroling
Following Player
Attack Player
*****************************************************************************************************************************/

public class LongBaseEnemy : MonoBehaviour
{
    [Header("Melee Attack")]
    public GameObject hitbox;

    [Header("Range Attack")]
    //Variables for attacking 
    public float projectileForce = 30.0f;
    public GameObject projectile;
    public Transform[] atkRangeLocations;
    public bool isShootAll = false;


    [Header("Gizmo Range")]
    //Variables to check whether or not able to see and attack player
    public float losRange = 10.0f;
    public float attackRange = 5.0f;
    public bool isPlayerInLOS;
    public bool isPlayerInAttackRange;

    private NavMeshAgent enemyNavMesh;

    public LayerMask layerMaskGround;
    public LayerMask layerMaskPlayer;

    private void Awake()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for player either in light of sight and within attack range
        isPlayerInLOS = Physics.CheckSphere(transform.position, losRange, layerMaskPlayer);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, layerMaskPlayer);
    }

    public bool Get_PlayerInAttackRangeStatus()
    {
        return isPlayerInAttackRange;
    }

    public bool Get_PlayerInLOSStatus()
    {
        return isPlayerInLOS;
    }

    public void StopWalking()
    {
        enemyNavMesh.SetDestination(this.transform.position);
        enemyNavMesh.speed = 0.0f;
    }

    public void SetDestinationAndSpeed(Vector3 destination, float speed = 10.0f)
    {
        enemyNavMesh.SetDestination(destination);
        enemyNavMesh.speed = speed;
    }

    public void Wander(float speed = 10.0f, float radius = 10.0f)
    {
        //Calculate random position    
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;

        SetDestinationAndSpeed(randomPos, speed);
    }

    public void FleeFromPlayer(float speed = 10.0f)
    {
        Vector3 dirToPlayer = transform.position - MasterGameSystem.Instance.GetPlayerPos();

        Vector3 newPos = transform.position + dirToPlayer;

        SetDestinationAndSpeed(newPos, speed);
    }

    public void Setup_AttackRange(GameObject _projectile, float _projectileForce, Transform[] _atkRangeLocations, bool _isShootAll = false)
    {
        projectile = _projectile;
        projectileForce = _projectileForce;
        atkRangeLocations = _atkRangeLocations;
        isShootAll = _isShootAll;
    }

    public void AttackPlayer_Range()
    {
        if (isShootAll == false)
        {
            //Get new transform to shoot
            Transform temp = atkRangeLocations[Random.Range(0, atkRangeLocations.Length)];

            //Look at player to shoot
            temp.LookAt(MasterGameSystem.Instance.player.transform.position);

            //At each locations, shoot the bullet
            Rigidbody rigidbody = Instantiate(projectile, temp.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rigidbody.AddForce(temp.forward * projectileForce, ForceMode.Impulse);
        }

        else if (isShootAll)
        {
            foreach (Transform shootTemp in atkRangeLocations)
            {
                //Look at player to shoot
                shootTemp.LookAt(MasterGameSystem.Instance.player.transform.position);

                //At each locations, shoot the bullet
                Rigidbody rigidbody = Instantiate(projectile, shootTemp.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rigidbody.AddForce(shootTemp.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }

    public void Setup_AttackMelee(GameObject _hitbox)
    {
        hitbox = _hitbox;
    }

    public void AttackPlayer_Melee()
    {
        StartCoroutine(AttackPlayer_MeleeCouroutine());
    }

    public void TeleportTo(Vector3 pos)
    {
        this.transform.position = pos;
    }

    public void RotateTowards(Transform target, float rotationRate = 1.0f)
    {
        Vector3 RotateToTarget = new Vector3(target.position.x, 0, target.position.z);

        Quaternion rotateTarget = Quaternion.LookRotation(RotateToTarget - transform.localPosition);

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotateTarget, rotationRate);

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    private IEnumerator AttackPlayer_MeleeCouroutine()
    {
        hitbox.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        hitbox.SetActive(false);
    }

    public void Setup_Bomb(GameObject _hitbox)
    {
        hitbox = _hitbox;
    }

    public void Bomb()
    {
        //Bomb Explode
        Instantiate(hitbox, this.transform.position, Quaternion.identity).SetActive(true);

        DestroyItself();
    }

    public void DestroyItself(float timeToDestroy = 0.0f)
    {
        GetComponent<EnemyHealth>().Die();
    }

    //Create sphere in order to help see where the ranges are
    //Debug GIZMO
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, losRange);
    }
}
