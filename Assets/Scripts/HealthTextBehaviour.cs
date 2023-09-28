using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTextBehaviour : MonoBehaviour
{
    public IntSO healthCounter;
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = $"Health: {healthCounter.value}";
    }
}
