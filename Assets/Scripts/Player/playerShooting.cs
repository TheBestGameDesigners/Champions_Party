﻿using UnityEngine;
using System.Collections;

public class playerShooting : MonoBehaviour {

    public GameObject currentWeapon;
    public GameObject bullet;
    public GameObject bulletPosition;
    public GameObject colisionObj;
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
        colisionObj = null;
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
                currentWeapon.GetComponent<Weapon>().Fire();

            }


        }

        
        if (Input.GetMouseButton(0) && currentWeapon) { 
            anim.SetInteger("action", currentWeapon.GetComponent<Weapon>().Animation_frame);
            currentWeapon.GetComponent<Weapon>().Fire();
            anim_duration = 5;
        }


    }

    void OnCollisionStay2D(Collision2D col)
    {
        colisionObj = col.gameObject;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        colisionObj = null;
    }
}
