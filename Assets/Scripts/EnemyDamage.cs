using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints=30;

	// Use this for initialization
	void Start ()
    {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Im hit");
        ProcessHit();
        if(hitPoints <=0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print("Current hitpoints: " + hitPoints);
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
