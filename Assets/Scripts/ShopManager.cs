using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public IntSO moneyCounter;

    public int startMoney = 250;

    private void Start()
    {
        moneyCounter.value = startMoney;
    }

    public void OnMoneyChange(GameObject gameObject, int money)
    {
        moneyCounter.value += money;
    }
}
