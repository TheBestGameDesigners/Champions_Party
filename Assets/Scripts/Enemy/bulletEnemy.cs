using UnityEngine;
using System.Collections;

public class bulletEnemy : MonoBehaviour {

    public float timeAttacks = 0.5f;
    public int damage = 30;
    public PlayerHealth p;
    public GameObject player;
    bool playerInRange = false;
    float timer;
    // Use this for initialization
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            applyDamage();
        }
    }

    void applyDamage()
    {

        if (p.currentHealth > 0)
            p.takeDamage(damage);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}
