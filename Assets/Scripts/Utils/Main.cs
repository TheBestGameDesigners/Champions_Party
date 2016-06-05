using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main : MonoBehaviour {

    // Use this for initialization

    GameObject player;
    GameObject inventario;
    GameObject HUD;
    GameObject Pause;
    public GameObject playerPrefab;
    public GameObject InventoryPrefab;
    public GameObject HUDPrefab;
    public GameObject PausePrefab;

    void Awake()
    {
        Manager m = Manager.m.getInstance();
        if (!m.HUD)
        {
            HUD = (GameObject) Instantiate(HUDPrefab);
            m.HUD = HUD;

        }
        if (!m.Pause)
        {
            Pause = (GameObject)Instantiate(PausePrefab);
            m.Pause = Pause;

        }

        if (!m.Inventory)
        {
            inventario = (GameObject)Instantiate(InventoryPrefab);
            m.Inventory = inventario;

        }

        if (!m.player)
        {
            player = (GameObject)Instantiate(playerPrefab, new Vector3(1500, -970, 0), Quaternion.Euler(0, 0, 0));
            player.tag = "Player";
            Manager.m.player = player;

        }
        else
            player = m.player;
        
        m.PlayerTransform = player.transform;

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
