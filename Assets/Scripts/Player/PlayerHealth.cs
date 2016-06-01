using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;
    Slider healthSlider;
	// Use this for initialization

	void Start () {
        currentHealth = startHealth;
        //GameObject hud = GameObject.FindGameObjectsWithTag("HUD")[0];
        healthSlider = GameObject.FindGameObjectsWithTag("HUD")[0].transform.Find("Slider").GetComponent<Slider>();
        healthSlider.value = currentHealth;
        healthSlider.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
            death();
    }

    void death()
    {
        Destroy(gameObject);
    }
}
