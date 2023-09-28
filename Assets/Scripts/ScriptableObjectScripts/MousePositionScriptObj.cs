using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionScriptObj : ScriptableObject
{
    private Vector3 mousePositionInWorld = Vector3.zero;

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
