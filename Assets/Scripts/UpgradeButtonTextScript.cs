using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonTextScript : MonoBehaviour
{
    public IntSO moneyCounter;
    public string upgradeName;
    public int cost;

    public Button button;
    public TextMeshProUGUI text;
    
    void Start()
    {
        text.text = new string($"{upgradeName}+ \n {cost}");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cost <= moneyCounter.value)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }

        
    }
    
    
    
}
