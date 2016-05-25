using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
	// Use this for initialization

    void Awake()
    {
        currentHealth = startHealth;
        //healthSlider = GameObject.FindGameObjectsWithTag("HUD")[0].GetComponent<Slider>();
       //healthSlider.enabled = false;
       // DontDestroyOnLoad(this);
    }
	void Start () {
        currentHealth = startHealth;
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
