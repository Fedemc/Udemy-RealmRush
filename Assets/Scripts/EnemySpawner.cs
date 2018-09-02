using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)][SerializeField][Tooltip("Seconds between spawns")] float secondsBetweenSpawns=1f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int numberOfEnemies;
    [SerializeField] Text txtEnemiesSpawned;
    private int spawnedEnemies;
    

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("SpawnEnemy");
        spawnedEnemies = 0;
        txtEnemiesSpawned.text = spawnedEnemies.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            var enemy=Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = gameObject.transform;
            spawnedEnemies++;
            txtEnemiesSpawned.text = spawnedEnemies.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
