using UnityEngine;
using System.Collections;

public class TrapLife : MonoBehaviour {


    public int percentLife;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Manager.m.healthPlayer = Manager.m.healthPlayer - ((Manager.m.healthPlayer * percentLife) / 100);
        }
        Destroy(gameObject);
    }
}
