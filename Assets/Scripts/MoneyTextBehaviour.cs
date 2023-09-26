using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTextBehaviour : MonoBehaviour
{
    public IntSO money;
    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = $"Money: {money.value}";
    }
}
