using UnityEngine;
using System.Collections;

public class bulletMove : MonoBehaviour {

    public float speedX;
    public float speedY;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        Destroy(gameObject);
    }
}
