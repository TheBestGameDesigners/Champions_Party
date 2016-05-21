using UnityEngine;
using System.Collections;

public class playerShooting : MonoBehaviour {


    public GameObject bullet;
    public GameObject bulletPosition;
    public float speed;
    Animator anim;
    float timer;

    void Awake() {
        anim = GetComponent<Animator>();
        timer = 0f;
    }
    
    void Start()
    {

    }

    void Fire()
    {
        /*GameObject bulletP = (GameObject)Instantiate(bullet);
        bulletP.transform.position = bulletPosition.transform.position;*/

        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        //...instantiating the rocket
        Rigidbody2D bulletInstance = (Rigidbody2D) Instantiate(bullet.GetComponent<Rigidbody2D>(), bulletPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
    }
    // Update is called once per frame
    void Update()
     {
        bool isShooting = Input.GetMouseButton(0);
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            anim.SetBool("isShooting", isShooting);
            timer = 0f;
        }
        
        
        
     }
}
