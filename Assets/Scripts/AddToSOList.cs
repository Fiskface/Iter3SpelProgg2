using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class AddToSOList : MonoBehaviour
{
    public ListScriptObj list;

    private void Awake()
    {
        list.list.Add(gameObject);
    }

    private void OnDisable()
    {
        list.list.Remove(gameObject);
    }
}
