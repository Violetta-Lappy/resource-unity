using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public enum Status
{
    Fire,
    Water,
    Poison,
    Electric,
    None
}


public class EnemyHealth : MonoBehaviour
{
    private bool isFlashing = false;
    private int flashTime; //times player have flash
    
    public WaveSystem spawner;
    public EndRoomManager endRoomManager;

    [Header("Health information")]
    public float currentHealth; //player current health
    public float maxHealth = 100; //player maximum health value

    [Header("Status effect")]
    public Status defaultStatus = Status.None;
    private Status currentStatus;
    public LayerMask canReceiveDamageFromExplosion;
    public float delayTimer = 2;
    
    [Header("Health feedback")]
    private float damageToReceive;
    private PlayerHealth dealerHealth;
    public float flashDuration = 0.15f; //time to flash
    public int timeToFlash = 3; //times player plashes when take a damage
    public Material flashingMat;
    public Renderer meshRenderer;
    
    public List<Material> _defaultMats = new List<Material>();
    
    private Dictionary<Status, System.Action> effects;

    private NavMeshAgent _navMeshAgent;

    bool died;
    // Start is called before the first frame update
    void Start()
    {
        InitReactionDataBase();

        currentStatus = defaultStatus;

        //set full health at start
        currentHealth = maxHealth;

        foreach (Material mat in meshRenderer.materials)
        {
            _defaultMats.Add(mat);
        }

        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void InitReactionDataBase()
    {
        effects = new Dictionary<Status, Action>
        {
            {Status.Fire, Fire},
            {Status.Water, Water},
            {Status.Poison, Poison},
            {Status.Electric, Electric},
        };
    }

    //Check whether the player is flashing
    //Decrease health by the value passed in as argument
    //Call FlashRoutine() below when player takes damage
    public void TakeDamage(float damage, Status dealerStatus = Status.None, PlayerHealth dealerRef = null)
    {
        if (isFlashing) return;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_TYPE.HIT_IMPACT);
        }

        damageToReceive = damage;

        if (dealerRef != null)
        {
            dealerHealth = dealerRef;
        }

        if (dealerStatus == Status.None)
        {
            //Dealing normal damage
            currentHealth -= damage;
        }
        else
        {
            TakeDamage(dealerStatus);
        }


        //if (currentStatus == Status.None)
        //{
        //    //decrease health
        //    currentHealth -= damage;

        //    if (dealerStatus != Status.None)
        //    {
        //        //Do inflict status on enemy
        //        currentStatus = dealerStatus;
        //    }
        //}
        //else
        //{
        //    #region New effect system

            

        //    #endregion


        //    #region Zombie reaction system
        //    //switch (currentStatus)
        //    //{
        //    //    case Status.Fire:
        //    //        switch (dealerStatus)
        //    //        {
        //    //            case Status.Water:
        //    //                TakeDamage(ElementReaction.Vaporize);
        //    //                break;
        //    //            case Status.Electric:
        //    //                TakeDamage(ElementReaction.Overload);
        //    //                break;
        //    //            case Status.Nature:
        //    //                TakeDamage(ElementReaction.Burning);
        //    //                break;
        //    //            default:
        //    //                {
        //    //                    //decrease health
        //    //                    currentHealth -= damage;

        //    //                    if (dealerStatus != Status.None)
        //    //                    {
        //    //                        //Do inflict status on enemy
        //    //                        currentStatus = dealerStatus;
        //    //                    }
        //    //                    break;
        //    //                }
        //    //        }
        //    //        break;
        //    //    case Status.Water:
        //    //        switch (dealerStatus)
        //    //        {
        //    //            case Status.Nature:
        //    //                TakeDamage(ElementReaction.Growth);
        //    //                break;
        //    //            case Status.Fire:
        //    //                TakeDamage(ElementReaction.Vaporize);
        //    //                break;
        //    //            case Status.Electric:
        //    //                TakeDamage(ElementReaction.ElectroCharged);
        //    //                break;
        //    //            default:
        //    //                {
        //    //                    //decrease health
        //    //                    currentHealth -= damage;

        //    //                    if (dealerStatus != Status.None)
        //    //                    {
        //    //                        //Do inflict status on enemy
        //    //                        currentStatus = dealerStatus;
        //    //                    }
        //    //                    break;
        //    //                }
        //    //        }
        //    //        break;
        //    //    case Status.Nature:
        //    //        switch (dealerStatus)
        //    //        {
        //    //            case Status.Water:
        //    //                TakeDamage(ElementReaction.Growth);
        //    //                break;
        //    //            case Status.Fire:
        //    //                TakeDamage(ElementReaction.Burning);
        //    //                break;
        //    //            default:
        //    //                {
        //    //                    //decrease health
        //    //                    currentHealth -= damage;

        //    //                    if (dealerStatus != Status.None)
        //    //                    {
        //    //                        //Do inflict status on enemy
        //    //                        currentStatus = dealerStatus;
        //    //                    }
        //    //                    break;
        //    //                }
        //    //        }
        //    //        break;
        //    //    case Status.Electric:
        //    //        switch (dealerStatus)
        //    //        {
        //    //            case Status.Water:
        //    //                TakeDamage(ElementReaction.ElectroCharged);
        //    //                break;
        //    //            case Status.Fire:
        //    //                TakeDamage(ElementReaction.Overload);
        //    //                break;
        //    //            default:
        //    //                {
        //    //                    //decrease health
        //    //                    currentHealth -= damage;

        //    //                    if (dealerStatus != Status.None)
        //    //                    {
        //    //                        //Do inflict status on enemy
        //    //                        currentStatus = dealerStatus;
        //    //                    }
        //    //                    break;
        //    //                }
        //    //        }
        //    //        break;
        //    //}
        //    #endregion
        //}


        //call FlashRoutine() and pass in time to flash
        StartCoroutine(FlashRoutine(flashDuration));
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    //Set player material to flashMaterial and
    //set it back to player's original material after the duration
    //Called by TakeDamage()
    //Called by DamageOverTime()
    IEnumerator FlashRoutine(float flashDuration)
    {
        for (int i = 0; i < timeToFlash; i++)
        {
            Material[] tempMats = meshRenderer.materials;
            isFlashing = true;

            // foreach (Material currentMat in meshRenderer.materials)
            // {
            //     currentMat = flashingMat;
            // }

            for (int x = 0; x < tempMats.Length; x++)
            {
                tempMats[x] = flashingMat;
            }

            meshRenderer.materials = tempMats;
            //meshRenderer.material = flashMat;
            yield return new WaitForSeconds(flashDuration);

            flashTime++;

            for (int x = 0; x < tempMats.Length; x++)
            {
                tempMats[x] = _defaultMats[x];
            }
            meshRenderer.materials = tempMats;

            //meshRenderer.material = originalMat;

            yield return new WaitForSeconds(flashDuration);
        }

        if (flashTime >= timeToFlash)
        {
            isFlashing = false;
            flashTime = 0;
        }
    }

    public void TakeDamage(Status effect = Status.None)
    {
        //Debug.Log("Taking damage");

        if (effect == Status.None) return;

        effects[effect]();

        //Stop concurrent coroutines
        //StopAllCoroutines();
        //StartCoroutine(ResetStatus());
    }


    private void Fire()
    {
        currentHealth -= damageToReceive * 5;
    }

    private void Poison()
    {
        StartCoroutine(DamageOverTime(3, 3));
    }


    private void Electric()
    {
        currentHealth -= damageToReceive;

        var enemiesInsideRadi = Physics.OverlapSphere(transform.position, 14f, canReceiveDamageFromExplosion);

        foreach (var enemy in enemiesInsideRadi)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damageToReceive);
        }
    }

    private void Water()
    {
        currentHealth -= damageToReceive;

        StartCoroutine(SlowCoroutine());
    }

    IEnumerator SlowCoroutine()
    {
        //Debug.Log("Speed before: " + _navMeshAgent.speed);
        float defaultSpeed = _navMeshAgent.speed;
        _navMeshAgent.speed = _navMeshAgent.speed * 0.5f;

        //Debug.Log("Speed after: " + _navMeshAgent.speed);

        yield return new WaitForSeconds(3);
        _navMeshAgent.speed = defaultSpeed;
    }

    public Status GetCurrentStatus()
    {
        return currentStatus;
    }

    IEnumerator ResetStatus()
    {
        yield return new WaitForSeconds(delayTimer);
        currentStatus = defaultStatus;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 14f);
    }

    public IEnumerator DamageOverTime(float damagePerTick, int duration = 3)
    {
        yield return new WaitForSeconds(0.65f);

        //Decrease health over time in 3 seconds
        for (int i = 0; i < Mathf.Max(1, duration); i++)
        {
            //Debug.Log("DOT");
            currentHealth -= damagePerTick;
            if (currentHealth <= 0)
            {
                Die();
            }
            StartCoroutine(FlashRoutine(flashDuration));
            yield return new WaitForSeconds(0.65f);
        }
    }

    public void Die()
    {
        if (!died)
        {
            if (spawner != null)
            {
                CurrencyManager.Instance.IncreaseCurrency(ENUM_CURRENCY_TYPE.COIN_MONEY, 50);

                AudioManager.Instance.PlaySFX_Game((ENUM_AUDIO_SFX_TYPE)UnityEngine.Random.Range(4, 8));

                spawner.RegisterKilled();
            }

            if (endRoomManager != null)
            {
                endRoomManager.RegisterKill();
            }
            
            Destroy(gameObject);
            died = true;
        }
    }
}
