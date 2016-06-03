using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;
    public int playerLive;       


    Animator anim;                        
    float restartTimer;                    


    void Awake()
    {
        playerLive = Manager.m.healthPlayer;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        

        if (Manager.m.healthPlayer <= 0)
        {
            
            anim.SetTrigger("GameOver");
           

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(0);
                Manager.m.healthPlayer = playerLive;

            }
        }
    }
}
