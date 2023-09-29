using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public float range = 5f;
    public float shootCooldown = 1f;
    public int damage = 1;
    public int cost;
    
    public GameObject RangeIndicator;
    
    private SpriteRenderer RISR;

    public GameEventInt selectTowerEvent;

    private void Start()
    {
        RISR = RangeIndicator.GetComponent<SpriteRenderer>();
        UpdateTowerRange();
        selectTowerEvent.Raise(gameObject, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //TODO: Fixa so man kan unselecta.
            //selectTowerEvent.Raise(null, 0);
        }
        
    }



    private void OnMouseDown()
    {
        selectTowerEvent.Raise(gameObject, 0);
    }

    public void OnSelectTower(GameObject tower, int value)
    {
        if (tower == gameObject)
        {
            RISR.enabled = true;
        }
        else
        {
            RISR.enabled = false;
        }
    }

    public void UpdateTowerRange()
    {
        var rangeTimesTwo = range * 2;
        RangeIndicator.transform.localScale = new Vector3(rangeTimesTwo, rangeTimesTwo, rangeTimesTwo);
    }

    public void OnUpgradeTower(GameObject gObject, int upgrade)
    {
        if (gObject == gameObject)
        {
            switch(upgrade) 
            {
                case 1:
                    UpgradeRange();
                    break;
                case 2:
                    // code block
                    break;
            }
        }
    }

    private void UpgradeRange()
    {
        range += 1;
        UpdateTowerRange();
    }
}
