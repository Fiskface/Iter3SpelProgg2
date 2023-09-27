using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower1Shoot : ShootParent
{
    [SerializeField] private GameObject shooter;
    [SerializeField] private GameObject bullet;
    [SerializeField] private List<GameObject> shootPositions;
    

    public override void Shoot(GameObject target, int damage)
    {
        shooter.transform.up = target.transform.position - shooter.transform.position;
        foreach (var shootpos in shootPositions)
        {
            var newBullet = Instantiate(bullet, shootpos.transform.position, Quaternion.identity);
            var bulletBehaviour = newBullet.GetComponent<Bullet1Behaviour>();
            bulletBehaviour.target = target;
            bulletBehaviour.damage = damage;
        }
    }
}
