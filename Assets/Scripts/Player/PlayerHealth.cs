using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
	// Use this for initialization

    void awake()
    {
        currentHealth = startHealth;
    }
	void Start () {
        currentHealth = startHealth;
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
