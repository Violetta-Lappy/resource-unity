using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added
using UnityEngine.UI;
using TMPro;

public class ShopExtension : MonoBehaviour
{
    public int id;
    public bool isItem = false;
    public bool isUpgrade = false;                

    public TextMeshProUGUI buttonName;

    public void setButtonName(string name)
    {
        buttonName.text = name;
    }

    public void Buy()
    {
        if (isItem)
        {
            Shop.Instance.BuyItem(id);
        }

        else if (isUpgrade)
        {
            Shop.Instance.BuyUpgrade(id);
        }
    }
}
