﻿using UnityEngine;
using System.Collections;

public class bonusBullet : MonoBehaviour {


    public int numBullets;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    

    public void actionBox()
    {
        if (GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerShooting>().currentWeapon != null)
        {
            GameObject weapon = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerShooting>().currentWeapon;
            if (weapon != null)
            {
                weapon.GetComponent<Weapon>().numBullet += numBullets;
               // Destroy(gameObject);
            }
        }
    }
}
