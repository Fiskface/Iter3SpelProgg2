using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Behaviour : MonoBehaviour
{
    public GameObject target;
    public Targetable targetTargetable;
    [NonSerialized] public int damage = 0;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        targetTargetable = target.GetComponent<Targetable>();
        targetTargetable.calculatedHealth -= damage;
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
            targetTargetable.hit(damage);
            Destroy(gameObject);
        }
    }
}
