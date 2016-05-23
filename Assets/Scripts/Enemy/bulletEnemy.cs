using UnityEngine;
using System.Collections;

public class bulletEnemy : MonoBehaviour {

    public float timeAttacks = 0.5f;
    public int damage = 30;
    GameObject player;
    PlayerHealth p;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        p = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void applyDamage()
    {
        if(p.currentHealth > 0)
         p.takeDamage(damage);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            applyDamage();
        }
    }
}
