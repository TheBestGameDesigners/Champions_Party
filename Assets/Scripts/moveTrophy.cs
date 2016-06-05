using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class moveTrophy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
         SceneManager.LoadScene(4);
       // Destroy(gameObject);
    }
}
