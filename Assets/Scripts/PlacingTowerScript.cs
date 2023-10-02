using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlacingTowerScript : MonoBehaviour
{
    private Camera myCamera;
    public ChooseTarget chooseTarget;
    public TowerStats towerStats;
    public IntSO moneyCounter;
    public GameEventInt buyTowerEvent;

    private List<Collider2D> blocking = new List<Collider2D>();
    private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

    void Awake()
    {
        myCamera = Camera.main;
        TryGetComponent<SpriteRenderer>(out SpriteRenderer spr);
        spriteRenderers.Add(spr);
        foreach (Transform child in transform)
        {
            if(child.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
            {
                spriteRenderers.Add(sr);
                
            }
        }

        foreach (var sr in spriteRenderers)
        {
            sr.sortingLayerName = "UI";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        var tempPos = myCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(tempPos.x, tempPos.y);

        if(blocking.Count == 0 && moneyCounter.value >= towerStats.cost)
        {
            SetSpriteColors(Color.green);
            if (Input.GetMouseButtonDown(0))
            {
                PlaceDown();
            }
        }
        else
        {
            SetSpriteColors(Color.red);
        }
    }
    

    private void PlaceDown()
    {
        towerStats.hasBeenPlaced = true;
        towerStats.selectTowerEvent.Raise(gameObject, 0);
        foreach (var sr in spriteRenderers)
        {
            sr.sortingLayerName = "Default";
        }
        SetSpriteColors(Color.white);
        buyTowerEvent.Raise(gameObject, towerStats.cost);
        chooseTarget.enabled = true;
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlockingPlacement"))
            blocking.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        blocking.Remove(other);
    }

    private void SetSpriteColors(Color color)
    {
        foreach (var sr in spriteRenderers)
        {
            sr.color = color;
        }
    }
    
}
