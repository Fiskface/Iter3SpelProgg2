using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int moneyGainOnDeath = 10;

    public int maxHealth = 5;

    [SerializeField] private GameEventInt gainMoneyEvent;
    [SerializeField] private Targetable targetable;
    public FloatSO healthMultiplier;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = (int)(maxHealth * healthMultiplier.value);
        targetable.calculatedHealth = currentHealth;
    }

    private void Update()
    {
        if(currentHealth<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        gainMoneyEvent.Raise(gameObject, moneyGainOnDeath);
        Destroy(gameObject);
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void OnEnable()
    {
        targetable.hit += TakeDamage;
    }

    private void OnDisable()
    {
        targetable.hit -= TakeDamage;
    }
}
