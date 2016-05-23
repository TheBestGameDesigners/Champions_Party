using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {


    public GameObject bullet;
    public GameObject bulletPosition;
    public GameObject enemy;
     GameObject player;

     PlayerHealth p;
    int damage = 20;
    public float speed;
    float timer;
    // Use this for initialization

    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        p = player.GetComponent<PlayerHealth>();
    }
    void Start () {
        timer = 0f;
        
	}

    void Fire()
    {
        Vector2 shootDirection;
        shootDirection = (player.transform.position - enemy.transform.position);
        //...instantiating the rocket
        Rigidbody2D bulletInstance = (Rigidbody2D)Instantiate(bullet.GetComponent<Rigidbody2D>(), bulletPosition.transform.position, Quaternion.Euler(new Vector2(0, 0)));
        bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > 3f && player != null)
        {
            Vector2 dir = player.transform.position - enemy.transform.position;
            // Only needed if objects don't share 'z' value.
            float distance = dir.sqrMagnitude;
            if (distance < 50000.04f)
            {
                Fire();
                timer = 0f;
            }
        }
	}

   public void applyDamage()
    {
        p.takeDamage(damage);
    }

}
