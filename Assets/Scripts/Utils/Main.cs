using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main : MonoBehaviour {

    // Use this for initialization

    GameObject player;
    GameObject inventario;
    GameObject HUD;
    GameObject Pause;
    GameObject trophy;
    public GameObject playerPrefab;
    public GameObject InventoryPrefab;
    public GameObject HUDPrefab;
    public GameObject PausePrefab;
    public GameObject trophyPrefab;
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

        if (!m.trophy)
        {
            int spawn = Random.Range(0,3);
            if (spawn == 2)
            {
                int spawnH = Random.Range(-200, -6200);
                int spawnW = Random.Range(200, 6200);
                float distance = Vector3.Distance(new Vector3(spawnW, spawnH, 0), player.transform.position);
                while (distance < 3000f)
                {
                    distance = Vector3.Distance(new Vector3(spawnW, spawnH, 0), player.transform.position);
                }
                trophy = (GameObject)Instantiate(trophyPrefab, new Vector3(spawnW, spawnH, 0), Quaternion.Euler(0, 0, 0));
                Manager.m.trophy = trophy;
            }
        }

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
