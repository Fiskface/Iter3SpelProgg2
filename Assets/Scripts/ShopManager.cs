using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public IntSO moneyCounter;
    public MoneyChangeObject moneyChange;

    public int startMoney = 250;

    private void Start()
    {
        moneyCounter.value = startMoney;
    }

    public void OnMoneyChange(MoneyChangeObject moneyChange, int money)
    {
        moneyCounter.value += money;
    }

    private void OnEnable()
    {
        moneyChange.onMoneyChange += OnMoneyChange;
    }
}
