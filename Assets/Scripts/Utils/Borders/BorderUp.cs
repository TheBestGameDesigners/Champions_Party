﻿using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class BorderUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().setCurrentItems(
           GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().getInventory().getItemList()
       );

        if (col.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(3);
    }
}
