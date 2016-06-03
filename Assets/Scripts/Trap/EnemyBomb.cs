using UnityEngine;
using System.Collections;

public class EnemyBomb : MonoBehaviour {

    public GameObject EnemyPrefab;
    public int numEnemies;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col) {

        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(EnemyPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        }
        Destroy(gameObject);
    }
}
