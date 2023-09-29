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

    private List<Collider2D> blocking = new List<Collider2D>();
    private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

    void Awake()
    {
        myCamera = Camera.main;
        TryGetComponent<SpriteRenderer>(out SpriteRenderer spr);
        spriteRenderers.Add(spr);
        foreach (Transform child in transform)
        {
            child.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr);
            {
                spriteRenderers.Add(sr);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var tempPos = myCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(tempPos.x, tempPos.y);

        if(blocking.Count == 0 && moneyCounter.value >= TowerStats.cost)
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
        SetSpriteColors(Color.white);
        BuyTowerEvent.Raise(gameObject, TowerStats.cost);
        ChooseTarget.enabled = true;
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
