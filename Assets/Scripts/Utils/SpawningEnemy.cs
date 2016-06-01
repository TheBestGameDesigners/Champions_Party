using UnityEngine;
using System.Collections;

public class SpawningEnemy : MonoBehaviour {

    PlayerHealth health;
    public GameObject enemy;
    public float spawnTime;
    public GameObject[] spawnPoints;
    public int numEnemies;
    // Use this for initialization
	void Start () {
        InvokeRepeating("spawnEnemy", spawnTime, spawnTime);
        health = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerHealth>();
	}
	
    void spawnEnemy()
    {
        if (health.currentHealth <= 0)
            return;
        if (numEnemies > 0 || numEnemies == -1)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            if (spawnPoints[spawnIndex] != null)
            {
                pointSpawn p = spawnPoints[spawnIndex].GetComponent<pointSpawn>();
                if (!p.visible)
                {
                    Instantiate(enemy, spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
                    numEnemies--;
                }
            }
        }
        else
            return;
    }
}
