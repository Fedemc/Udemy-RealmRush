using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float distanceToShoot=10f;
    [SerializeField] ParticleSystem towerBullet;
    [SerializeField] AudioClip shootSFX;

    public Waypoint baseWaypoint;  //where the tower is standing


    //State
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();

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

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length==0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemy)
    {
        Transform retorno;
        float closestEnemyDistance = Vector3.Distance(transform.position, closestEnemy.transform.position);
        float testEnemyDistance = Vector3.Distance(transform.position, testEnemy.position);

        if(closestEnemyDistance<testEnemyDistance)
        {
            retorno = closestEnemy;
        }
        else
        {
            retorno = testEnemy;
        }

        return retorno;
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
        /* Para terminar una vez que pueda controlar que no se sobrepongan los audios
        if (isActive)
            gameObject.GetComponent<AudioSource>().PlayOneShot(shootSFX);
        */
    }

    private void LookAtEnemy(Transform targetEnemy)
    {
        objectToPan.LookAt(targetEnemy);
    }
}
