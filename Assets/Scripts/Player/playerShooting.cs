using UnityEngine;
using System.Collections;

public class playerShooting : MonoBehaviour {

    public GameObject currentWeapon;
    public GameObject bullet;
    public GameObject bulletPosition;
    public float speed;
    Animator anim;
    float timer;
    float timerFire;

    private int anim_duration;
    

    void Awake() {
        anim = GetComponent<Animator>();
        timer = 0f;
        anim_duration = 0; 
    }
    
    void Start()
    {

    }

    void Fire()
    {
        /*GameObject bulletP = (GameObject)Instantiate(bullet);
        bulletP.transform.position = bulletPosition.transform.position;*/

       // if (timerFire > 0.5f)
        //{
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;
            //...instantiating the rocket
            Rigidbody2D bulletInstance = (Rigidbody2D)Instantiate(bullet.GetComponent<Rigidbody2D>(), bulletPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
            timerFire = 0f;
        //}
    }
    // Update is called once per frame
    void Update()
     {

        /*
        bool isShooting = Input.GetMouseButton(0);
        timerFire += Time.deltaTime;

            anim.SetBool("isShooting", isShooting);
        */
        if (anim_duration > 0)
        {
            anim_duration--;

            if (anim_duration == 0) { 
                anim.SetInteger("action", 0);
                Fire();

            }


        }

        
        if (Input.GetMouseButton(0) && currentWeapon) { 
            anim.SetInteger("action", currentWeapon.GetComponent<Weapon>().Animation_frame);
            anim_duration = 5;
        }


    }
}
