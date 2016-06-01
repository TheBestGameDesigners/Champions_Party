using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main : MonoBehaviour {

    // Use this for initialization

    GameObject player;
    public GameObject playerPrefab;
    public GameObject InventoryPrefab;

    void Awake()
    {
        DontDestroyOnLoad(this);
        //if(SceneManager.GetActiveScene().buildIndex == 1)
            player = (GameObject)Instantiate(playerPrefab, new Vector3(1579, -970, -1), Quaternion.Euler(0, 0, 0));
        player.tag = "Player";
        Instantiate(InventoryPrefab);
    }
	void Start () {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    void OnLevelWasLoaded(int level)
    {
       // player = (GameObject)Instantiate(playerPrefab);
        if (level == 2)
        {
            player.transform.position = player.transform.position - new Vector3(6300, 0, 0);
        }
        else if (level == 3)
        {
            player.transform.position = player.transform.position - new Vector3(0, 6300, 0);
        }

    }
}
