#define DEBUG_MODE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Singleton<Shop>
{
    public ShopDatabase shopDatabase;

    public GameObject button;

    public GameObject itemContent;
    public GameObject upgradeContent;

    void Start()
    {
        //Make item buttons
        for(int i = 0; i < shopDatabase.itemDB.Length; i++)
        {
            GameObject temp = Instantiate(button, itemContent.transform);

            //Set button name
            temp.GetComponent<ShopExtension>().setButtonName(shopDatabase.itemDB[i].itemName);        

            temp.GetComponent<ShopExtension>().id = shopDatabase.itemDB[i].id;            
            temp.GetComponent<ShopExtension>().isItem = true;            
            temp.SetActive(true);
        }

        //Make upgrade buttons
        for (int i = 0; i < shopDatabase.upgradeDB.Length; i++)
        {
            GameObject temp = Instantiate(button, upgradeContent.transform);

            //Set button name
            temp.GetComponent<ShopExtension>().setButtonName(shopDatabase.upgradeDB[i].upgradeName);        

            temp.GetComponent<ShopExtension>().id = shopDatabase.upgradeDB[i].id;            
            temp.GetComponent<ShopExtension>().isUpgrade = true;
            temp.SetActive(true);
        }
    }
    
    void Update()
    {
        
    }

    public void BuyItem(int itemID)
    {
        if(CompareMoney(shopDatabase.itemDB[itemID].cost) == true)
        {
            //Player lost the money to the stuff
            CoinScript.Instance.coin -= shopDatabase.itemDB[itemID].cost;

            //Spawn the good stuff
            Instantiate(shopDatabase.itemDB[itemID].outputPrefab);

            //GUIManager.Instance.SetValue_PlayerMoney(CoinScript.Instance.coin);
        }

        else if (CompareMoney(shopDatabase.itemDB[itemID].cost) == false)
        {

#if DEBUG_MODE
Debug.Log("Ya can't buy the item, not sufficient fund");     
#endif

        }
    }

    public void BuyUpgrade(int upgradeID)
    {
        if(CompareMoney(shopDatabase.upgradeDB[upgradeID].cost) == true)
        {
            //Player lost the money to the stuff
            CoinScript.Instance.coin -= shopDatabase.upgradeDB[upgradeID].cost;

            //Spawn the good stuff
            switch(upgradeID)
            {
                case 0:
                    PlayerStat.Instance.UpgradeHealth_Percent(shopDatabase.upgradeDB[upgradeID].upgradePercent);
                break;

                case 1:
                    PlayerStat.Instance.UpgradeHealth_Percent(shopDatabase.upgradeDB[upgradeID].upgradePercent);
                break;

                case 2:
                    PlayerStat.Instance.UpgradeStamina_Percent(shopDatabase.upgradeDB[upgradeID].upgradePercent);
                break;

                case 3:
                    PlayerStat.Instance.UpgradeStamina_Percent(shopDatabase.upgradeDB[upgradeID].upgradePercent);
                break;
            }

            //GUIManager.Instance.SetValue_PlayerMoney(CoinScript.Instance.coin);
        }

        else if (CompareMoney(shopDatabase.upgradeDB[upgradeID].cost) == false)
        {

#if DEBUG_MODE
Debug.Log("Ya can't buy the upgrade, not sufficient fund");     
#endif

        }
    }

    public bool CompareMoney(float value)
    {
        //If player does not have enough money, don't allow player to buy
        if (CoinScript.Instance.coin < value)
            return false;

        //If player have enough, then allow
        else
            return true;
    }
}
