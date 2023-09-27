using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "EventInt", menuName = "ScriptableObjects/EventWithInt")]
    public class GameEventInt : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise(GameObject gameObject, int value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(gameObject, value);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }
        
        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
