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
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        
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
              
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.color = new Color(1.0f, 1.0f, 1.0f);
            }
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            if (anim.runtimeAnimatorController.animationClips.Length > 1)
            {
                float time = anim.runtimeAnimatorController.animationClips[1].length;
                anim.SetBool("isDead", true);
                Invoke("death", time);
            }
        }
    }

    void death()
    {
        Destroy(anim);
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
        
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 0.0f, 0.0f);
    }
}
