using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 25/10/2021
Object(s) holding this script: Coin
Summary: 
Move to player after a certain time since being spawned and magnetiseCoin option is chosen
Increase player's current coin
***************************/

public class Coin : MonoBehaviour
{
    public float coinSpeed = 3f; //coin moving speed
    public float timeWait = 6f; //time to wait to move to player 
    private float waitingTime = 0f; //time since being spawned
    private GameObject player; //player gameobject
    private CoinScript coinScript; //player script
    public int value = 1; // coin value

    // Start is called before the first frame update
    void Start()
    {
        waitingTime = timeWait; 

        coinScript = CoinScript.Instance;        

        player = GameObject.Find("Player");        
    }

    // Update is called once per frame
    //Move coins to player position if out of waiting time and magnetiseCoin option is chosen
    void Update()
    {
        waitingTime -= Time.deltaTime;

        //if out of waiting time and magnetiseCoin option is chosen
        /*
        if (waitingTime <= 0 && coinScript.magnetiseCoin == true)
        {
            //move to player 
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, coinSpeed * Time.deltaTime);
        }
        */        
    }

    //Called by PlayerExample.OnCollisionEnter() when player collides with a coin
    public void AddCoin()
    {
        //add value to player current coin 
        coinScript.coin += value;

        //GUIManager.Instance.SetValue_PlayerMoney(coinScript.coin);
    }
}
