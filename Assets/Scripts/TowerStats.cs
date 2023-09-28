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
    private bool canSelect = true;

    public GameEventInt selectTowerEvent;

    private void Start()
    {
        RISR = RangeIndicator.GetComponent<SpriteRenderer>();
        UpdateTowerRange();
        selectTowerEvent.Raise(gameObject, 0);
    }

    private void OnMouseDown()
    {
        if (canSelect)
        {
            selectTowerEvent.Raise(gameObject, 0);
        }
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
}
