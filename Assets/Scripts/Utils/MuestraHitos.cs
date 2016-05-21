using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuestraHitos : MonoBehaviour {
    public Text textoHUD;
    public GestorHitos gh;
	// Use this for initialization
	void Start () {
        string s = "";
	    foreach(Hito h in gh.getHitos())
        {
           s += h.muestraHito()+ "\n";
        }
        textoHUD.text = s;
	}
	
	// Update is called once per frame
	void Update () {
        string s ="";
        foreach (Hito h in gh.getHitos())
        {
            s += h.muestraHito() + "\n";
        }
        textoHUD.text = s;
    }
}
