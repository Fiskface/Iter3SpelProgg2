using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Behaviour : MonoBehaviour
{
    public GameObject target;
    [NonSerialized] public int damage = 0;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position +=  speed * Time.deltaTime * (target.transform.position - transform.position).normalized;
        if (MyMath.Close(transform.position, target.transform.position))
        {
            target.GetComponent<Targetable>().hit(damage);
            Destroy(gameObject);
        }
    }
}
