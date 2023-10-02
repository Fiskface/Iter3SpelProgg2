using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class ChooseTarget : MonoBehaviour
{
    [SerializeField] private ListScriptObj enemyList;
    [SerializeField] private TowerStats towerStats;

    private List<Targetable> enemiesInRangeTargetable = new List<Targetable>();
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        CheckForEnemiesInRange();
        FindCurrentTarget();
    }

    private void CheckForEnemiesInRange()
    {
        enemiesInRangeTargetable.Clear();
        foreach (var enemy in enemyList.list)
        {
            if ((transform.position - enemy.transform.position).magnitude < towerStats.range)
            {
                if(enemy.TryGetComponent<Targetable>(out Targetable targetable))
                {
                    enemiesInRangeTargetable.Add(targetable);
                }
            }
        }
    }

    private void FindCurrentTarget()
    {
        
        if (enemiesInRangeTargetable.Count > 0)
        {
            for (int i = 0; i < enemiesInRangeTargetable.Count; i++)
            {
                if (enemiesInRangeTargetable[i].calculatedHealth > 0)
                {
                    target = enemiesInRangeTargetable[i].gameObject;
                    break;
                }
                target = null;
            }
            
        }
        else
        {
            target = null;
        }
    }
}
