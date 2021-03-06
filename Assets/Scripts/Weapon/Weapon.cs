﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Weapon : MonoBehaviour {


    public string name;
    public int Animation_frame;
    public bool cuerpoAcuerpo;
    public int numBulletInstanciate;
    public int numBullet;
    public GameObject bullet;
    GameObject bulletPosition;
    public float speed;
    Text texto;



    // Use this for initialization
    void Start () {
        //bulletPosition = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerShooting>().bulletPosition;
        //bulletPosition = GameObject.Find("bulletPosition");
       texto =  GameObject.FindGameObjectsWithTag("HUD")[0].transform.Find("Text").GetComponent<Text>();
    }

    public void Fire()
    {
        /*GameObject bulletP = (GameObject)Instantiate(bullet);
        bulletP.transform.position = bulletPosition.transform.position;*/
        if (!cuerpoAcuerpo)
        {
            if (numBullet > 0)
            {
                Vector3 shootDirection;
                shootDirection = Input.mousePosition;
                shootDirection.z = 0.0f;
                shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
                shootDirection = shootDirection - GameObject.FindGameObjectsWithTag("Player")[0].transform.position;

                bulletPosition = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerShooting>().bulletPosition;
                //...instantiating the rocket
                Vector3 v = new Vector3(30, 30, 0);
                float speedShoot = speed;
                for (int i = 0; i < numBulletInstanciate; i++)
                {
                    if (name == "shotgun")
                    {
                        if (i != 0)
                        {
                            shootDirection += v;
                            v = -v;
                        }
                    }
                    else if(name == "machineGun")
                    {
                        if(i != 0)
                        {
                            speedShoot -= 0.5f;
                        }
                    }
                    GameObject bulletInstance = (GameObject)Instantiate(bullet, bulletPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * speedShoot, shootDirection.y * speedShoot);
                    numBullet--;
                }
            }
            else
            {
                texto.text = "No tienes balas";
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
