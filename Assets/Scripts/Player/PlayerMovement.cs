using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour {
	
	
	public float speed = 6f;
    public float initialSpeed;
    public bool iceMan;

    public float timeIceMan;
    Vector2 movement; //guarda la direccion del jugador
    private Rigidbody2D body;


    void Awake(){
        body = GetComponent<Rigidbody2D>();
        body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        body.interpolation = RigidbodyInterpolation2D.Extrapolate;
       // DontDestroyOnLoad(this);

    }

    void Start()
    {
        Vector3 posicion = Manager.m.PlayerTransform.position;
        transform.position = posicion;
        initialSpeed = speed;
    }

    void Update()
    {
        if (iceMan)
        {
            timeIceMan -= Time.deltaTime;
            if(timeIceMan <= 0)
            {
                speed = initialSpeed;
            }
        }
    }

    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Move(x, y);
        // Rotate player
        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - objectPos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
       // Manager.m.PlayerTransform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
    }
	


  
    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, v);

        
        Vector3 pos = transform.position;
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;
        transform.position = pos;
        //Manager.m.PlayerTransform.position = pos;
    }
}
