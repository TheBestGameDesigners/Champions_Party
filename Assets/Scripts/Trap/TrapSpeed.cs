using UnityEngine;
using System.Collections;

public class TrapSpeed : MonoBehaviour {

    public float percentSpeedTrap;
    public float timeTrap;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        PlayerMovement playerMove = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>();
        playerMove.iceMan = true;
        playerMove.timeIceMan = timeTrap;
        playerMove.speed = playerMove.speed - ((playerMove.speed * percentSpeedTrap) / 100);
        Destroy(gameObject);
    }
}
