using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main : MonoBehaviour {

    // Use this for initialization

    GameObject player;
    GameObject inventario;
    GameObject HUD;
    public GameObject playerPrefab;
    public GameObject InventoryPrefab;
    public GameObject HUDPrefab;

    void Awake()
    { 

        if (!Manager.m.HUD)
        {
            HUD = (GameObject) Instantiate(HUDPrefab);
            Manager.m.HUD = HUD;

        }

        if (!Manager.m.Inventory)
        {
            inventario = (GameObject)Instantiate(InventoryPrefab);
            Manager.m.Inventory = inventario;

        }

        if (!Manager.m.player)
        {
            player = (GameObject)Instantiate(playerPrefab, new Vector3(5000, -970, 0), Quaternion.Euler(0, 0, 0));
            player.tag = "Player";
            Manager.m.player = player;

        }
        else
            player = Manager.m.player;
        
        Manager.m.PlayerTransform = player.transform;

    }
	
    void Start()
    {
        player.GetComponent<PlayerInventory>().inventory = GameObject.FindGameObjectsWithTag("MainInventory")[0];
        player.GetComponent<PlayerInventory>().characterSystem = GameObject.FindGameObjectsWithTag("EquipmentSystem")[0];
    }
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Player")[0] != null)
            Manager.m.PlayerTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    
}
