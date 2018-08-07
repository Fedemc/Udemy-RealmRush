using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float distanceToShoot;
    [SerializeField] GameObject towerBullet;

    // Update is called once per frame
    void Update()
    {
        LookAtEnemy(targetEnemy);
        CalculateDistance();
    }

    private void CalculateDistance()
    {
        if (Vector3.Distance(gameObject.transform.position, targetEnemy.position) <= distanceToShoot)
        {
            ShootEnemy();
        }
    }

    private void ShootEnemy()
    {
        Instantiate(towerBullet, transform.position, transform.rotation);
        towerBullet.GetComponent<Rigidbody>().velocity = 1*(targetEnemy.position - towerBullet.transform.position);
    }

    private void LookAtEnemy(Transform targetEnemy)
    {
        objectToPan.LookAt(targetEnemy);
    }
}
