using UnityEngine;
using System.Collections;

public class EnemyAtack : MonoBehaviour {

    public float timeAttacks = 0.5f;
    public int damage = 20;
    public PlayerHealth p;
    public GameObject player;
    bool playerInRange = false;
    float timer;
	// Use this for initialization
	void Start () {
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= timeAttacks && playerInRange)
        {
            applyDamage();
        }
	}

    void applyDamage()
    {
        timer = 0f;

        if (p.currentHealth > 0)
            p.takeDamage(damage);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
