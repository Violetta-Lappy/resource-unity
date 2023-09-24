using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Team Team => _team;
    [SerializeField] private Team _team;
    [SerializeField] private LayerMask _layerMask;

    private float attackRange = 3f;
    private float rayDistance = 5.0f;
    private float stoppingDistance = 1.5f;

    private Vector3 destinations;
    private Quaternion desiredDestination;
    private Vector3 direction;
    private Enemy target;
    private EnemyState currentState;


    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Wander:
                {
                    if (NeedsDestination())
                    {
                        GetDestination();
                    }

                    transform.rotation = desiredDestination;

                    transform.Translate(Vector3.forward * Time.deltaTime * 5f);

                    var rayColor = IsPathBlocked() ? Color.red : Color.green;
                    Debug.DrawRay(transform.position, direction * rayDistance, rayColor);

                    while (IsPathBlocked())
                    {
                        Debug.Log("Path Blocked");
                        GetDestination();
                    }

                    var targetToAggro = CheckForAggro();
                    if (targetToAggro != null)
                    {
                        target = targetToAggro.GetComponent<Enemy>();
                        currentState = EnemyState.Chase;
                    }

                    break;
                }
            case EnemyState.Chase:
                {
                    if (target == null)
                    {
                        currentState = EnemyState.Wander;
                        return;
                    }

                    transform.LookAt(target.transform);
                    transform.Translate(Vector3.forward * Time.deltaTime * 5f);

                    if (Vector3.Distance(transform.position, target.transform.position) < attackRange)
                    {
                        currentState = EnemyState.Attack;
                    }
                    break;
                }
            case EnemyState.Attack:
                {
                    if (target != null)
                    {
                        Destroy(target.gameObject);
                    }

                    // play laser beam

                    currentState = EnemyState.Wander;
                    break;
                }
        }
    }

    private bool IsPathBlocked()
    {
        Ray ray = new Ray(transform.position, direction);
        var hitSomething = Physics.RaycastAll(ray, rayDistance, _layerMask);
        return hitSomething.Any();
    }

    private void GetDestination()
    {
        Vector3 testPosition = (transform.position + (transform.forward * 4f)) +
                               new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0f,
                                   UnityEngine.Random.Range(-4.5f, 4.5f));

        destinations = new Vector3(testPosition.x, 1f, testPosition.z);

        direction = Vector3.Normalize(destinations - transform.position);
        direction = new Vector3(direction.x, 0f, direction.z);
        desiredDestination = Quaternion.LookRotation(direction);
    }

    private bool NeedsDestination()
    {
        if (destinations == Vector3.zero)
            return true;

        var distance = Vector3.Distance(transform.position, destinations);
        if (distance <= stoppingDistance)
        {
            return true;
        }

        return false;
    }



    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    private Transform CheckForAggro()
    {
        float aggroRadius = 5f;

        RaycastHit hit;
        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;
        for (var i = 0; i < 24; i++)
        {
            if (Physics.Raycast(pos, direction, out hit, aggroRadius))
            {
                var drone = hit.collider.GetComponent<Enemy>();
                if (drone != null && drone.Team != gameObject.GetComponent<Enemy>().Team)
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    return drone.transform;
                }
                else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(pos, direction * aggroRadius, Color.white);
            }
            direction = stepAngle * direction;
        }

        return null;
    }
}

public enum Team
{
    Red,
    Blue
}

public enum EnemyState
{
    Wander,
    Chase,
    Attack
}
