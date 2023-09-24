using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 20/10/2021
Object(s) holding this script: Player
Summary: 
Set health
Player flashes when taking damage
Player only takes damage when he is no longer flashing
***************************/

public class PlayerExample : Singleton<PlayerExample>
{
    public float currentHealth; //player current health
    public float maxHealth = 100; //player maximum health value
    public Material flashMat; //material when player takes damage
    private Material originalMat; //player's orginal material
    public float flashDuration = 0.15f; //time to flash
    private bool isFlashing = false;
    private int flashTime; //times player have flash
    public int timeToFlash = 3; //times player plashes when take a damage
    public int coin = ProjectConstants.PLAYER_DEFAULT_MONEY; // player current coin 
    public bool magnetiseCoin = false; //oprion to magnetise Coins or not


    // Start is called before the first frame update
    void Start()
    {
        //Update UI
        //GUIManager.Instance.SetValue_PlayerMoney(coin);

        //set full health at start
        currentHealth = maxHealth;

        //get the player's orginal material
        originalMat = GetComponent<MeshRenderer>().material;
    }

     void Update()
    {
        //test code 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Heal(5);
        }
    }

    //Check whether the player is flashing
    //Decrease health by the value passed in as argument
    //Call FlashRoutine() below when player takes damage
    public void TakeDamage(int damage)
    {
        //when the player is no longer flashing
        if(isFlashing == false)
        {
            //decrease health
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                currentHealth = 0;    
                Die();        
            }

            //call FlashRoutine() and pass in time to flash
            StartCoroutine(FlashRoutine(flashDuration));

            //GUIManager.Instance.UpdateUI_Health();

        } else //while the player is flasing
        {
            Debug.Log("it's flashing");
        }
       
    }

    public void Die()
    {        
        Destroy(this.gameObject);
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

    //Set player material to flashMaterial and
    //set it back to player's original material after the duration
    //Called by TakeDamage()
    IEnumerator FlashRoutine(float flashDuration)
    {
        for (int i = 0; i < timeToFlash; i++)
        {
            isFlashing = true;

            GetComponent<MeshRenderer>().material = flashMat;

            yield return new WaitForSeconds(flashDuration);

            flashTime++;

            GetComponent<MeshRenderer>().material = originalMat;

            yield return new WaitForSeconds(flashDuration);

        }

        if(flashTime >= timeToFlash)
        {
            isFlashing = false;
            flashTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.GetComponent<Coin>().AddCoin();

            Destroy(collision.gameObject);

            Debug.Log("Player is having " + coin + " coins");
        }
    }

    /*
    public void ModValue_Money(float value)
    {
        money += value;
    }
    */

}
