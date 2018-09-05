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
    [SerializeField] AudioClip enemyHitSFX, enemyDyingSFX;
    private Transform vfxParent;
    private AudioSource myAudioSource;

	// Use this for initialization
	void Start ()
    {
		vfxParent= GameObject.Find("DeathFXs").transform;
        myAudioSource = GetComponent<AudioSource>();
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
        myAudioSource.PlayOneShot(enemyHitSFX);
    }

    private void KillEnemy()
    {
        var vfx=Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.transform.parent = vfxParent;
        vfx.Play();
        float vfxDelay = vfx.main.duration;
        Destroy(vfx.gameObject,vfxDelay);
        AudioSource.PlayClipAtPoint(enemyDyingSFX, Camera.main.transform.position);
        //Debug.Break();
        Destroy(gameObject);
    }
}
