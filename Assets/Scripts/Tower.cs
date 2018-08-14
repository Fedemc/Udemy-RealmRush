using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float distanceToShoot=10f;
    [SerializeField] ParticleSystem towerBullet;

    // Update is called once per frame
    void Update()
    {
        if(targetEnemy)
        {
            LookAtEnemy(targetEnemy);
            CalculateDistance();
        }
        else
        {
            AttackEnemy(false);
        }
    }

    private void CalculateDistance()
    {
        float distanceToEnemy = Vector3.Distance(gameObject.transform.position, targetEnemy.position);
        if (distanceToEnemy <= distanceToShoot)
        {
            AttackEnemy(true);
        }
        else
        {
            AttackEnemy(false);
        }
    }

    private void AttackEnemy(bool isActive)
    {
        var emissionModule = towerBullet.emission;
        emissionModule.enabled = isActive;
    }

    private void LookAtEnemy(Transform targetEnemy)
    {
        objectToPan.LookAt(targetEnemy);
    }
}
