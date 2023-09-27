using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundTextBehaviour : MonoBehaviour
{
    public IntSO roundCounter;
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = $"Round: {roundCounter.value}";
    }
}
