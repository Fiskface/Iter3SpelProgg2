using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public IntSO healthCounter;

    public int startHealth = 250;

    private void Start()
    {
        healthCounter.value = startHealth;
    }

    public void OnHealthChange(GameObject gameObject, int health)
    {
        healthCounter.value += health;
    }
}
