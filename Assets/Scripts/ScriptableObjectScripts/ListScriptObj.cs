using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "List", menuName = "ScriptableObjects/List", order = 2)]
    public class ListScriptObj : ScriptableObject
    {
        public List<GameObject> list = new List<GameObject>();
    }
}
