using UnityEngine;
using System.Collections;

public class moveTrophy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 100);
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
}
