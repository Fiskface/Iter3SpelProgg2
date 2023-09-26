using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private ChooseTarget chooseTarget;
    [SerializeField] private ShootParent shootParent;
    [SerializeField] private TowerStats towerStats;

    private bool canShoot = true;


    private void Update()
    {
        if (canShoot && chooseTarget.target != null)
        {
            shootParent.Shoot(chooseTarget.target);
            canShoot = false;
            StartCoroutine(ShootCooldown());
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(towerStats.shootCooldown);
        canShoot = true;
    }
}
