using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
	// Use this for initialization
	void Start () {
        currentHealth = startHealth;
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
