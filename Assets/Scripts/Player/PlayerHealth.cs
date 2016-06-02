using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private int cont;
    public int startHealth = 100;
    public int currentHealth;
    Slider healthSlider;
    Animator anim;
	// Use this for initialization

    void Awake() {

        anim = GetComponent<Animator>();
    }
	void Start () {
        
        currentHealth = Manager.m.healthPlayer;
        //GameObject hud = GameObject.FindGameObjectsWithTag("HUD")[0];
        healthSlider = GameObject.FindGameObjectsWithTag("HUD")[0].transform.Find("Slider").GetComponent<Slider>();
        healthSlider.value = currentHealth;
        healthSlider.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        cont = anim.runtimeAnimatorController.animationClips.Length;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        Manager.m.healthPlayer = currentHealth;
        if (currentHealth <= 0)
        {
            if (anim.runtimeAnimatorController.animationClips.Length > 1)
            {
                float time = anim.runtimeAnimatorController.animationClips[3].length;
                Debug.Log(time);

                anim.SetBool("isDead", true);
                Invoke("death", time);
            }
        }
    }

    void death()
    {
        Destroy(gameObject);
        Destroy(anim);


    }
}
