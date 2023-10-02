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

    [NonSerialized] public bool hasBeenPlaced = false;
    
    public GameObject RangeIndicator;
    
    private SpriteRenderer RISR;

    public GameEventInt selectTowerEvent;

    private void Start()
    {
        RISR = RangeIndicator.GetComponent<SpriteRenderer>();
        UpdateTowerRange();
        selectTowerEvent.Raise(gameObject, 1);
    }

    private void OnMouseDown()
    {
        if(hasBeenPlaced)
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
                    UpgradeDamage();
                    break;
                case 3:
                    UpgradeAttackSpeed();
                    break;
            }
        }
    }

    private void UpgradeRange()
    {
        range += 0.5f;
        UpdateTowerRange();
    }

    private void UpgradeDamage()
    {
        damage++;
    }

    private void UpgradeAttackSpeed()
    {
        shootCooldown *= 0.9f;
    }
}
