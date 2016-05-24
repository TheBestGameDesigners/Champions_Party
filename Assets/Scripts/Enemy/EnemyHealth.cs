using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public int startHealth = 100;
    public int currentHealth;

    // Use this for initialization

    public Color[] originalColors;
    public Material[] materials;// All the Materials of this & its child
    public int remainingDamageFrames = 0;
    public int showDamageForFrames = 5;
    private Color originalColor;

    void awake()
    {
        originalColor = GetComponent<SpriteRenderer>().color;   
    }
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingDamageFrames > 0)
        {
            remainingDamageFrames--;
            if (remainingDamageFrames == 0)
            {
                //GetComponent<SpriteRenderer>().color = originalColor;
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.color = new Color(1.0f, 1.0f, 1.0f);
            }
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            death();
    }

    void death()
    { 
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag("bullet"))
        {
            takeDamage(25);
            ShowDamage();      
        }
    }

    void ShowDamage()
    {
        remainingDamageFrames = 5;
        //GetComponent<SpriteRenderer>().color = Color.red;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 0.0f, 0.0f);
    }
}
