using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "Path", menuName = "ScriptableObjects/MapPath", order = 1)]
    public class PathCheckpoints : ScriptableObject
    {
        [SerializeField] private GameObject checkpointsGameObject;
        [SerializeField] private List<Transform> checkpointsList = new List<Transform>();

    
        private void OnValidate()
        {
            checkpointsList.Clear();
            foreach(Transform child in checkpointsGameObject.transform)
            {
                checkpointsList.Add(child);
            }
        }

        private void Awake()
        {
            checkpointsList.Clear();
            foreach(Transform child in checkpointsGameObject.transform)
            {
                checkpointsList.Add(child);
            }
        }

        public Transform GetNextCheckpoint(int current)
        {
            if(current + 1 < checkpointsList.Count)
                return checkpointsList[current + 1];

            return null;
        }
    }
}
