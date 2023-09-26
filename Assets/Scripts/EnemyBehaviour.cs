using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public MoneyChangeObject moneyChange;
    public int moneyGainOnDeath = 10;

    public int maxHealth = 5;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            moneyChange.MoneyChange(moneyGainOnDeath);
        }
    }
}
