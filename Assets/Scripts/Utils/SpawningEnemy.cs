﻿using UnityEngine;
using System.Collections;

public class SpawningEnemy : MonoBehaviour {

    public PlayerHealth health;
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;
    public int numEnemies;
    // Use this for initialization
	void Start () {
        InvokeRepeating("spawnEnemy", spawnTime, spawnTime);
	}
	
    void spawnEnemy()
    {
        if (health.currentHealth <= 0)
            return;
        if (numEnemies > 0)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            numEnemies--;
        }
        else
            return;
    }
}
