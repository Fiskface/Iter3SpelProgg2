using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1Shoot : ShootParent
{
    [SerializeField] private GameObject shooter;
    [SerializeField] private GameObject bullet;
    
    public override void Shoot(GameObject target)
    {
        shooter.transform.up = target.transform.position - shooter.transform.position;
    }
}
