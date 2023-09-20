using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private PathCheckpoints checkpointsSO;
    
    private int currentCheckpoint = -1;

    [SerializeField] private float speed = 3f;

    private Vector3 movingTowards;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = checkpointsSO.GetNextCheckpoint(currentCheckpoint).position;
        currentCheckpoint++;
        SwapCheckpoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyMath.CloseOrPassed(transform.position, direction, movingTowards))
        {
            SwapCheckpoint();
        }

        transform.position += speed * Time.deltaTime * direction;
    }

    private void SwapCheckpoint()
    {
        var tempCheckpoint = checkpointsSO.GetNextCheckpoint(currentCheckpoint);
        if(tempCheckpoint != null)
        {
            movingTowards = tempCheckpoint.position;
            currentCheckpoint++;
            direction = (movingTowards - transform.position).normalized;
            transform.up = direction;
        }
        else
        {
            EnemyAtLastCheckpoint();
        }
    }

    private void EnemyAtLastCheckpoint()
    {
        Debug.Log("Kill me");
    }
}
