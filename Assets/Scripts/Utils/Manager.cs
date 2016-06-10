using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

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
    public GameObject Pause;
    public GameObject trophy;

    private List<Item> currentItems;


    public void setCurrentItems(List<Item> l)
    {
        currentItems = l;

    }
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
	
    public Manager getInstance()
    {
        if (!m)
        {
            m = this;
            DontDestroyOnLoad(gameObject);
        }
        return m;
    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnLevelWasLoaded(int level)
    {
        if (GameObject.FindGameObjectsWithTag("Player")[0] != null)
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
                if ((player.transform.position - new Vector3(0, 6200, 0)).y > -6400)
                    player.transform.position = player.transform.position - new Vector3(0, 6200, 0);
            }
            else if (level == 1)
            {
                if ((player.transform.position + new Vector3(6200, 0, 0)).x < 6400)
                    player.transform.position = player.transform.position + new Vector3(6200, 0, 0);
                else if ((player.transform.position + new Vector3(0, 6200, 0)).y < 0)
                    player.transform.position = player.transform.position + new Vector3(0, 6200, 0);
            }

            CheckInventory();


            if (currentItems != null)
            {
                Inventory inv = player.GetComponent<PlayerInventory>().getInventory();
                foreach(var item in currentItems)
                {
                    inv.addItemToInventory(item.itemID);
                    
                }
            }
                

        }



        
    }

    void CheckInventory()
    {
        if (player != null)
        {
            PlayerInventory pInvent = player.GetComponent <PlayerInventory> ();
            pInvent.Start();

        
        }
    }
}
