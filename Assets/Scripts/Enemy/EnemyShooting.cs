using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {


    public GameObject bullet;
    public GameObject bulletPosition;
    public GameObject enemy;
    public GameObject player;

    public PlayerHealth p;
    int damage = 20;
    public float speed;
    float timer;
    // Use this for initialization
    void Start () {
        timer = 0f;
        p = player.GetComponent<PlayerHealth>();
	}

    void Fire()
    {
        /*GameObject bulletP = (GameObject)Instantiate(bullet);
        bulletP.transform.position = bulletPosition.transform.position;*/

        Vector2 shootDirection;
        shootDirection = (player.transform.position - enemy.transform.position);
        //...instantiating the rocket
        Rigidbody2D bulletInstance = (Rigidbody2D)Instantiate(bullet.GetComponent<Rigidbody2D>(), bulletPosition.transform.position, Quaternion.Euler(new Vector2(0, 0)));
        bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            Fire();
            timer = 0f;
        }
	}

   public void applyDamage()
    {
        p.takeDamage(damage);
    }

}
