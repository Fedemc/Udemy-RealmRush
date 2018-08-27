using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints=10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

	// Use this for initialization
	void Start ()
    {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Im hit");
        ProcessHit();
        if(hitPoints <=0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        var vfx=Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.transform.parent = GameObject.Find("DeathFXs").transform;
        vfx.Play();
        float vfxDelay = vfx.main.duration;
        Destroy(vfx.gameObject,vfxDelay);
        Destroy(gameObject);
    }
}
