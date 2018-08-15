using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)][SerializeField][Tooltip("Seconds between spawns")] float secondsBetweenSpawns=1f;
    [SerializeField] GameObject enemyPrefab;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("SpawnEnemy");	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < 5; i++)
        {
            var enemy=Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
