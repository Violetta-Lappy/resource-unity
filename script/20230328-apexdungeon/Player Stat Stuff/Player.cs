using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public float money = ProjectConstants.PLAYER_DEFAULT_MONEY;

    public float health;
    
    void Start()
    {
        //GUIManager.Instance.SetValue_PlayerMoney(money);
    }
    
    void Update()
    {
        
    }

    public void ModValue_Money(float value)
    {
        money += value;
    }

    public void TakeDamage(float value)
    {
        health -= value;

        if(health <= 0)
        {
            health = 0;    
            Die();        
        }
    }

    public void Die()
    {
        //Do something here
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {            
            money += collision.gameObject.GetComponent<Coin>().value;   

            Destroy(collision.gameObject);                     
        }
    }
}
