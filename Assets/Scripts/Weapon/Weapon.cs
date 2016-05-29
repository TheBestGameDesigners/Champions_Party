using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


    public string name;
    public int Animation_frame;
    public bool cuerpoAcuerpo;
    public int numBullet;
    public GameObject bullet;
    GameObject bulletPosition;
    public float speed;
   


    // Use this for initialization
    void Start () {
        //bulletPosition = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerShooting>().bulletPosition;
        //bulletPosition = GameObject.Find("bulletPosition");
	}

    public void Fire()
    {
        /*GameObject bulletP = (GameObject)Instantiate(bullet);
        bulletP.transform.position = bulletPosition.transform.position;*/
        if (!cuerpoAcuerpo)
        {
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - GameObject.FindGameObjectsWithTag("Player")[0].transform.position;

            bulletPosition = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerShooting>().bulletPosition;
            //...instantiating the rocket
            for (int i = 0; i < numBullet; i++)
            {
                Rigidbody2D bulletInstance = (Rigidbody2D)Instantiate(bullet.GetComponent<Rigidbody2D>(), bulletPosition.transform.position, Quaternion.Euler(new Vector3(0 , 0 , 0)));
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
    }

    // Update is called once per frame
    void Update () {
	
	}
}
