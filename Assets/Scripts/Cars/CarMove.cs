using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour {

    public int speed;
    public bool sentidoUp;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 v2 = gameObject.transform.position;
        if (sentidoUp)
            v2 += Vector2.up * Time.deltaTime * speed;
        else
        {
            v2 += Vector2.down * Time.deltaTime * speed;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
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
