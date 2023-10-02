using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public IntSO healthCounter;

    public int startHealth = 250;

    public GameEventInt gameOver;
    
    private void Start()
    {
        healthCounter.value = startHealth;
    }

    public void OnHealthChange(GameObject gameObject, int health)
    {
        healthCounter.value += health;
        if (healthCounter.value <= 0)
        {
            Time.timeScale = 0;
            gameOver.Raise(gameObject, 0);
        }
    }
}
