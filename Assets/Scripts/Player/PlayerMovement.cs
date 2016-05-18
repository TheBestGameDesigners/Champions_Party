using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour {
	
	
	public float speed = 6f;


    /* reworking */
    Vector2 movement; //guarda la direccion del jugador
    private Rigidbody2D body;


    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Move(x, y);

        // Rotate player
        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - objectPos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
    }
	


  
    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, v);


        Vector3 pos = transform.position;
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;
        transform.position = pos;
      
    }


    void OnTriggerEnter2D(Collider2D other){
        body.AddForce((-1)*movement * (2)*speed, ForceMode2D.Impulse);            
    }

  

    void OnTriggerExit2D(Collider2D other)
    {
        body.velocity = Vector2.zero;

    }
}
