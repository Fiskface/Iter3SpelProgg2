using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class ChooseTarget : MonoBehaviour
{
    [SerializeField] private ListScriptObj enemyList;
    [SerializeField] private TowerStats towerStats;

    private List<GameObject> enemiesInRange = new List<GameObject>();
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        CheckForEnemiesInRange();
        FindCurrentTarget();
    }

    private void CheckForEnemiesInRange()
    {
        enemiesInRange.Clear();
        foreach (var enemy in enemyList.list)
        {
            if ((transform.position - enemy.transform.position).magnitude < towerStats.range)
            {
                enemiesInRange.Add(enemy);
            }
        }
    }

    private void FindCurrentTarget()
    {
        if (enemiesInRange.Count > 0)
        {
            target = enemiesInRange[0];
        }
        else
        {
            target = null;
        }
    }
}
