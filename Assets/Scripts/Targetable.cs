using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Targetable : MonoBehaviour
{
    public int calculatedHealth;
    
    public UnityAction<int> hit = delegate {};
    
}
