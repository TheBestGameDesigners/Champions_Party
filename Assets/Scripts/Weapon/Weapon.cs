using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


    public string name;
    public int Animation_frame;
    public bool cuerpoAcuerpo;
    public int numBullet;
    public GameObject bullet;
    public GameObject bulletPosition;
    public int speed;
  

	// Use this for initialization
	void Start () {
	}

    public void Fire()
    {
        /*GameObject bulletP = (GameObject)Instantiate(bullet);
        bulletP.transform.position = bulletPosition.transform.position;*/

        // if (timerFire > 0.5f)
        //{
        if (!cuerpoAcuerpo)
        {
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;
            //...instantiating the rocket
            for (int i = 0; i < numBullet; i++)
            {
                Rigidbody2D bulletInstance = (Rigidbody2D)Instantiate(bullet.GetComponent<Rigidbody2D>(), bulletPosition.transform.position, Quaternion.Euler(new Vector3(0 + i, 0 + i, 0)));
                bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
            }
        }
        else
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            GameObject enemy = player.GetComponent<playerShooting>().colisionObj;
            if (enemy  != null)
            {
                enemy.GetComponent<EnemyHealth>().takeDamage(10);
            }
        }
        //}
    }

    // Update is called once per frame
    void Update () {
	
	}
}
