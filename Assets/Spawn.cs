using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemy;
    public float spawnRadius = 1f;
    public float spawnRate = 1f;
   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    void SpawnEnemy()
    {
        // Instantiate a new GameObject
        GameObject enemySpawned = Instantiate(enemy);
        //Position it to a random place within the screen
        enemy.transform.position = Random.insideUnitCircle * spawnRadius;

    }

    // Use this for initialization
    void Start () {
        Invoke("SpawnEnemy", spawnRate);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
