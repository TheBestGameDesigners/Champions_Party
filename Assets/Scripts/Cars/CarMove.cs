using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 v2 = gameObject.transform.position;

        v2 += Vector2.up * Time.deltaTime * 500;

        gameObject.transform.position = v2;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
