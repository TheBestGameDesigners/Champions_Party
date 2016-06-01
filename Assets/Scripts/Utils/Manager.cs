﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour {

    public static Manager m;
    public int healthPlayer;
    public int oldScene;
    public int currentScene;
    public Transform PlayerTransform;
    public GameObject currentWeapon;
    public GameObject player;
    public GameObject Inventory;
    public GameObject HUD;

    void Awake()
    {
        if (!m)
        {
            m = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {
        CheckInventory();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnLevelWasLoaded(int level)
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        if (level == 2)
        {
            if ((player.transform.position - new Vector3(6200, 0, 0)).x > 0)
                player.transform.position = player.transform.position - new Vector3(6200, 0, 0);
           /* else
                Destroy(player);*/
        }
        else if (level == 3)
        {
            player.transform.position = player.transform.position - new Vector3(0, 6300, 0);
        }
        else if (level == 1)
        {
            if ((player.transform.position + new Vector3(6200, 0, 0)).x < 6400)
                player.transform.position = player.transform.position + new Vector3(6200, 0, 0);
            /*else
                Destroy(player);*/
        }



        CheckInventory();
    }

    void CheckInventory()
    {
        if (player != null)
        {
            PlayerInventory pInvent = player.GetComponent <PlayerInventory> ();
            pInvent.setInput();

        
        }
    }
}