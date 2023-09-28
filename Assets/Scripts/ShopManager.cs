using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public IntSO moneyCounter;

    public int startMoney = 250;

    private GameObject currentlyTryingToBuy;

    private void Start()
    {
        moneyCounter.value = startMoney;
    }

    public void OnMoneyChange(GameObject gameObject, int money)
    {
        moneyCounter.value += money;
    }

    public void GetTowerOnMouse(GameObject prefab)
    {
        Destroy(currentlyTryingToBuy);
        currentlyTryingToBuy = Instantiate(prefab);
    }

    public void BuyTower(GameObject gObject, int cost)
    {
        moneyCounter.value -= cost;
        currentlyTryingToBuy = null;
    }
}
