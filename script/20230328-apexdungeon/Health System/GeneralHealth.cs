using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementReaction
{
    Vaporize, //Water + Fire
    Burning, //Fire + Nature
    Growth, //Water + Nature
    ElectroCharged, //Water + Electric
    Overload, //Fire + electric 
    None
}

public class GeneralHealth : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public WaveSystem spawner;


    [Header("Health information")]
    public float currentHealth; //player current health
    public float maxHealth = 100; //player maximum health value

    [Header("Invulnerable frames")]
    public Material flashMat; //material when player takes damage
    public Material originalMat; //object's orginal material
    public float flashDuration = 0.15f; //time to flash
    public int timeToFlash = 3; //times player plashes when take a damage

    [Header("Status effect")]
    public Status defaultStatus = Status.None;
    private Status currentStatus;
    public LayerMask canReceiveDamageFromExplosion;
    public float delayTimer = 2;

    private bool isFlashing = false;
    private int flashTime; //times player have flash
    private float damageToReceive;
    private GeneralHealth dealerHealth;

    public GameObject losePanel;

    private Dictionary<ElementReaction, System.Action> Reactions;

    bool died;
    // Start is called before the first frame update
    void Start()
    {
        InitReactionDataBase();

        currentStatus = defaultStatus;

        //set full health at start
        currentHealth = maxHealth;

        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        //get the player's orginal material
        if (originalMat == null)
        {
            originalMat = meshRenderer.material;
        }
    }


    void InitReactionDataBase()
    {
        Reactions = new Dictionary<ElementReaction, Action>
        {
            {ElementReaction.Vaporize, Vaporize},
            {ElementReaction.Burning, Burning},
            {ElementReaction.Growth, Growth},
            {ElementReaction.ElectroCharged, ElectroCharged},
            {ElementReaction.Overload, Overload}
        };
    }

    //Check whether the player is flashing
    //Decrease health by the value passed in as argument
    //Call FlashRoutine() below when player takes damage
    public void TakeDamage(float damage, Status dealerStatus = Status.None, GeneralHealth dealerRef = null)
    {
        //when the player is no longer flashing
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

        if (currentStatus == Status.None)
        {
            //decrease health
            currentHealth -= damage;

            if (dealerStatus != Status.None)
            {
                //Do inflict status on enemy
                currentStatus = dealerStatus;
            }
        }
        else
        {
            //switch (currentStatus)
            //{
            //    case Status.Fire:
            //        switch (dealerStatus)
            //        {
            //            case Status.Water:
            //                TakeDamage(ElementReaction.Vaporize);
            //                break;
            //            case Status.Electric:
            //                TakeDamage(ElementReaction.Overload);
            //                break;
            //            case Status.Nature:
            //                TakeDamage(ElementReaction.Burning);
            //                break;
            //            default:
            //                {
            //                    //decrease health
            //                    currentHealth -= damage;

            //                    if (dealerStatus != Status.None)
            //                    {
            //                        //Do inflict status on enemy
            //                        currentStatus = dealerStatus;
            //                    }
            //                    break;
            //                }
            //        }
            //        break;
            //    case Status.Water:
            //        switch (dealerStatus)
            //        {
            //            case Status.Nature:
            //                TakeDamage(ElementReaction.Growth);
            //                break;
            //            case Status.Fire:
            //                TakeDamage(ElementReaction.Vaporize);
            //                break;
            //            case Status.Electric:
            //                TakeDamage(ElementReaction.ElectroCharged);
            //                break;
            //            default:
            //                {
            //                    //decrease health
            //                    currentHealth -= damage;

            //                    if (dealerStatus != Status.None)
            //                    {
            //                        //Do inflict status on enemy
            //                        currentStatus = dealerStatus;
            //                    }
            //                    break;
            //                }
            //        }
            //        break;
            //    case Status.Nature:
            //        switch (dealerStatus)
            //        {
            //            case Status.Water:
            //                TakeDamage(ElementReaction.Growth);
            //                break;
            //            case Status.Fire:
            //                TakeDamage(ElementReaction.Burning);
            //                break;
            //            default:
            //                {
            //                    //decrease health
            //                    currentHealth -= damage;

            //                    if (dealerStatus != Status.None)
            //                    {
            //                        //Do inflict status on enemy
            //                        currentStatus = dealerStatus;
            //                    }
            //                    break;
            //                }
            //        }
            //        break;
            //    case Status.Electric:
            //        switch (dealerStatus)
            //        {
            //            case Status.Water:
            //                TakeDamage(ElementReaction.ElectroCharged);
            //                break;
            //            case Status.Fire:
            //                TakeDamage(ElementReaction.Overload);
            //                break;
            //            default:
            //                {
            //                    //decrease health
            //                    currentHealth -= damage;

            //                    if (dealerStatus != Status.None)
            //                    {
            //                        //Do inflict status on enemy
            //                        currentStatus = dealerStatus;
            //                    }
            //                    break;
            //                }
            //        }
            //        break;
            //}
        }

        if (currentHealth <= 0)
        {
            Die();
        }

        //call FlashRoutine() and pass in time to flash
        StartCoroutine(FlashRoutine(flashDuration));
    }

    public void TakeDamage(ElementReaction reaction = ElementReaction.None)
    {
        if (reaction == ElementReaction.None) return;

        Reactions[reaction]();

        StartCoroutine(ResetStatus());
    }


    //Increase health by the value passed in as argument
    public void Heal(int value)
    {
        //increase health
        currentHealth += value;

        //health cannot pass the maximum value
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Flash(float flashDuration = 0.15f)
    {
        StartCoroutine(FlashRoutine(flashDuration));
    }

    public void Die()
    {
        if (!died)
        {
            if (spawner != null)
            {
                spawner.RegisterKilled();
            }

            Destroy(gameObject);
            died = true;
        }
        //losePanel.SetActive(true);
        //Time.timeScale = 0;
    }

    //Set player material to flashMaterial and
    //set it back to player's original material after the duration
    //Called by TakeDamage()
    //Called by DamageOverTime()
    IEnumerator FlashRoutine(float flashDuration)
    {
        for (int i = 0; i < timeToFlash; i++)
        {
            isFlashing = true;

            meshRenderer.material = flashMat;

            yield return new WaitForSeconds(flashDuration);

            flashTime++;

            meshRenderer.material = originalMat;

            yield return new WaitForSeconds(flashDuration);

        }

        if (flashTime >= timeToFlash)
        {
            isFlashing = false;
            flashTime = 0;
        }
    }

    private void Vaporize()
    {
        print("Enemy receives vaporize");

        damageToReceive *= 2;

        currentHealth -= damageToReceive;

        currentStatus = Status.None;
    }

    private void Burning()
    {
        currentHealth -= damageToReceive;

        StartCoroutine(DamageOverTime(3));

        currentStatus = Status.None;
    }

    private void Growth()
    {
        if (dealerHealth != null)
        {
            dealerHealth.Heal(5);
        }

        currentStatus = Status.None;
    }

    private void ElectroCharged()
    {
        currentStatus = Status.None;
    }

    private void Overload()
    {
        var enemiesInsideRadi = Physics.OverlapSphere(transform.position, 10f, canReceiveDamageFromExplosion);

        foreach (var enemy in enemiesInsideRadi)
        {
            enemy.GetComponent<GeneralHealth>().TakeDamage(damageToReceive);
        }
        currentStatus = Status.None;
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }

    public IEnumerator DamageOverTime(float damagePerTick)
    {
        yield return new WaitForSeconds(1f);

        //Decrease health over time in 3 seconds
        for (int i = 0; i < 3; i++)
        {
            currentHealth -= damagePerTick;
            StartCoroutine(FlashRoutine(flashDuration));
            yield return new WaitForSeconds(1f);
        }
    }
}


