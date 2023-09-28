using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using Unity.VisualScripting;
using UnityEngine;

public class PlacingTowerScript : MonoBehaviour
{
    private Camera myCamera;
    public ChooseTarget ChooseTarget;
    public TowerStats TowerStats;
    public IntSO moneyCounter;
    public GameEventInt BuyTowerEvent;

    private List<Collision2D> blocking = new List<Collision2D>();

    void Awake()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var tempPos = myCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(tempPos.x, tempPos.y);

        if (Input.GetMouseButtonDown(0) && blocking.Count == 0 && moneyCounter.value >= TowerStats.cost)
        {
            PlaceDown();
        }
    }
    

    private void PlaceDown()
    {
        BuyTowerEvent.Raise(gameObject, TowerStats.cost);
        ChooseTarget.enabled = true;
        enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        blocking.Add(other);
        Debug.Log(other.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        blocking.Remove(other);
    }
}
