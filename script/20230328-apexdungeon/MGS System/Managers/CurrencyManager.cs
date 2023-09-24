using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_CURRENCY_TYPE
{
    COIN_MONEY,
    RUNE
}

//Switch this into Singleton
public class CurrencyManager : Singleton_Blank<CurrencyManager>
{
    public int coin = 0;
    public int rune = 0;

    private void Start()
    {
        coin = SaveDataMNG.Load_GameCurrency();
    }

    public bool ReportNotEnough()
    {
        //Debug.Log("Not enough money to buy this item");

        //Update UI

        return false;
    }

    public bool CompareCurrency(int valueToCompare, ENUM_CURRENCY_TYPE currencyType)
    {
        switch (currencyType)
        {
            case ENUM_CURRENCY_TYPE.COIN_MONEY: return valueToCompare < coin ? true : ReportNotEnough();
            case ENUM_CURRENCY_TYPE.RUNE: return valueToCompare < rune ? true : ReportNotEnough();

            default: return false;
        }
    }

    public bool CompareCurrency(int valueA, int valueB)
    {
        return valueA > valueB;
    }

    public void IncreaseCurrency(ENUM_CURRENCY_TYPE currencyType, int value = 0)
    {
        //Force the value always positive
        int tempValue = UnityEngine.Mathf.Abs(value);

        //Increase the stats based on tempValue
        CalculateCurrency(currencyType, tempValue);
    }

    public void DecreaseCurrency(ENUM_CURRENCY_TYPE currencyType, int value = 0)
    {
        //Force the value always positive
        int tempValue = UnityEngine.Mathf.Abs(value) * -1;

        //Increase the stats based on tempValue
        CalculateCurrency(currencyType, tempValue);
    }

    private void CalculateCurrency(ENUM_CURRENCY_TYPE currencyType, int value)
    {
        switch (currencyType)
        {
            case ENUM_CURRENCY_TYPE.COIN_MONEY:
                coin += value;

                SaveDataMNG.Save_GameCurrency(coin);

                GUIManager.Instance.UpdateText(ENUM_UI_TEXT_TYPE.CURRENCY_COIN);
                break;

            case ENUM_CURRENCY_TYPE.RUNE:
                rune += value;
                break;

            default:
                break;
        }
    }
}
