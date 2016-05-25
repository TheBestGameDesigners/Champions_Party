using UnityEngine;
using System.Collections;

public class EnemyAtack : MonoBehaviour {

    public float timeAttacks = 0.5f;
    public int damage = 20;
    PlayerHealth p;
    GameObject player;
    bool playerInRange = false;
    float timer;
	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            p = player.GetComponent<PlayerHealth>();
        }
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (p != null)
        {
            timer += Time.deltaTime;

            if (timer >= timeAttacks && playerInRange)
            {
                applyDamage();
            }
        }
	}

    void applyDamage()
    {
        timer = 0f;

        if (p.currentHealth > 0)
            p.takeDamage(damage);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
