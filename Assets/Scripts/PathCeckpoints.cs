using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathCeckpoints : MonoBehaviour
{
    [SerializeField] private GameObject checkpointsGameObject;
    private List<Transform> checkpointsList = new List<Transform>();
    private int currentCheckpoint = 0;
    private int lastCheckpoint;

    private void Start()
    {
        foreach (Transform child in checkpointsGameObject.transform)
        {
            checkpointsList.Add(child);
        }

        lastCheckpoint = checkpointsList.Count - 1;
    }

    public Transform GetNextCheckPoint()
    {
        return null;
    }
}
