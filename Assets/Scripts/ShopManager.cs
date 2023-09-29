using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public IntSO moneyCounter;

    public int startMoney = 250;

    public GameEventInt upgradeTower;

    private GameObject currentlyTryingToBuy;
    private GameObject highlightedTower;

    private void Start()
    {
        moneyCounter.value = startMoney;
    }

    public void OnMoneyChange(GameObject gObject, int money)
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

    public void SelectTower(GameObject gObject, int inter)
    {
        highlightedTower = gObject;
    }

    public void UpgradeTower(int upgrade)
    {
        upgradeTower.Raise(highlightedTower, upgrade);
    }

    public void UpgradeTowerLoseMoney(int money)
    {
        moneyCounter.value -= money;
    }
}
