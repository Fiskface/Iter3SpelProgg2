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
    
    public GameObject RangeIndicator;
    
    private SpriteRenderer RISR;
    private bool canSelect = true;

    public GameEventInt selectTowerEvent;

    private void Start()
    {
        RISR = RangeIndicator.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (canSelect)
        {
            selectTowerEvent.Raise(gameObject, 0);
            
        }
    }

    public void OnSelectTower(GameObject tower)
    {
        Debug.Log(tower.name);
        if (gameObject == tower)
        {
            RISR.enabled = true;
            Debug.Log("1");
        }
        else
        {
            RISR.enabled = false;
            Debug.Log("2");
        }
    }
}
