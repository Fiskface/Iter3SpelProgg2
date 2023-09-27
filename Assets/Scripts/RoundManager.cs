using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public IntSO roundCounter;
    public ListScriptObj aliveEnemies;
    public List<GameObject> enemiesThatCanSpawn;

    private List<GameObject> enemiesToSpawn;
    private void Start()
    {
        roundCounter.value = 1;
    }
}
