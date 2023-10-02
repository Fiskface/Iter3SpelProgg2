using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public float timeBetweenSpawns;
    [Range(0,1)] public float timeBetweenSpawnsReduction = 0.99f;
    public float timeBetweenRounds = 3;
    public FloatSO healthMultiplier;
    public IntSO roundCounter;
    public ListScriptObj aliveEnemies;
    public List<GameObject> enemiesThatCanSpawn;
    public PathCheckpoints checkPoints;

    private int firstEnemyHarder = 2;
    private int secondEnemyHarder = 5;
    private int thirdEnemyHarder = 10;

    private List<int> enemyHarderList = new List<int>();

    private List<GameObject> enemiesToSpawn = new List<GameObject>();
    private bool canSpawn = true;
    private bool roundStarted = false;
    
    private void Start()
    {
        enemyHarderList.Add(firstEnemyHarder);
        enemyHarderList.Add(secondEnemyHarder);
        enemyHarderList.Add(thirdEnemyHarder);
        healthMultiplier.value = 1;
        roundCounter.value = 1;
    }

    private void Update()
    {
        if(roundStarted)
        {
            SpawnEnemies();
            CheckIfRoundOver();
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                StartNextRound();
            }
        }
    }

    private void SpawnEnemies()
    {
        if (enemiesToSpawn.Count > 0 && canSpawn)
        {
            Instantiate(enemiesToSpawn[0], checkPoints.GetNextCheckpoint(-1).position, Quaternion.identity);
            enemiesToSpawn.RemoveAt(0);
            canSpawn = false;
            StartCoroutine(SpawnCooldown());
        }
    }
    
    private void CheckIfRoundOver()
    {
        if (aliveEnemies.list.Count <= 0 && enemiesToSpawn.Count <= 0)
        {
            roundCounter.value++;
            if (roundCounter.value % 12 == 0)
            {
                for (int i = 0; i < enemyHarderList.Count; i++)
                {
                    if(enemyHarderList[i] > 1)
                        enemyHarderList[i] -= 1;
                    
                }
            }
            healthMultiplier.value += 0.08f;
            timeBetweenSpawns *= timeBetweenSpawnsReduction;
            StartCoroutine(WaitBetweenRounds());
        }
    }

    private void StartNextRound()
    {
        roundStarted = true;
        for (int i = 1; i <= roundCounter.value; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                enemiesToSpawn.Add(enemiesThatCanSpawn[0]);
            }

            if (i % thirdEnemyHarder == 0)
            {
                enemiesToSpawn.Add(enemiesThatCanSpawn[3]);
                continue;
            }
            if (i % secondEnemyHarder == 0)
            {
                enemiesToSpawn.Add(enemiesThatCanSpawn[2]);
                continue;
            }
            if (i % firstEnemyHarder == 0)
            {
                enemiesToSpawn.Add(enemiesThatCanSpawn[1]);
                continue;
            }
            
            enemiesToSpawn.Add(enemiesThatCanSpawn[0]);
        }
    }
    
    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        canSpawn = true;
    }
    
    IEnumerator WaitBetweenRounds()
    {
        roundStarted = false;
        yield return new WaitForSeconds(timeBetweenRounds);
        StartNextRound();
    }
}
