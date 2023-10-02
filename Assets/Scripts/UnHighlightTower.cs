using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class UnHighlightTower : MonoBehaviour
{
    public GameEventInt SelectTower;

    private void OnMouseDown()
    {
        SelectTower.Raise(null, 0);
    }
}
