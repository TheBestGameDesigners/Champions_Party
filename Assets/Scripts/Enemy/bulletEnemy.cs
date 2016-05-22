using UnityEngine;
using System.Collections;

public class bulletEnemy : MonoBehaviour {

    public float timeAttacks = 0.5f;
    public int damage = 30;
    public EnemyShooting enemy;
    // Use this for initialization
    void Start()
    {
        //p = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void applyDamage()
    {

        enemy.applyDamage();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            applyDamage();
        }
    }
}
