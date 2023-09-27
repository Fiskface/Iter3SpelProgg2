using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEventInt Event;

    public UnityEvent<GameObject, int> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(GameObject gObject, int value)
    {
        Response.Invoke(gObject, value);
    }
}
