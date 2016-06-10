using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mensajes : MonoBehaviour {

    Text texto;
    float time;

	// Use this for initialization
	void Start () {
        texto = gameObject.GetComponent<Text>();
        }
	
	// Update is called once per frame
	void Update () {
	    if(texto.text != "")
        {
            time += Time.deltaTime;
            if(time >= 3f)
            {
                texto.text = "";
                time = 0f;
            }
        }
	}
}
