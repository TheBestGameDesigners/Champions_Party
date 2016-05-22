using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuestraHitos : MonoBehaviour {
    public Text textoHUD;
    GestorHitos gh;
    public GameObject game;
    Hito h;
    ArrayList lista;
    int index;
    // Use this for initialization
    void awake()
    {
        gh = game.GetComponent<GestorHitos>();
    }
    void Start () {
        string s = "";
        index = 0;
        gh = game.GetComponent<GestorHitos>();
        lista = gh.getHitos();
        h = (Hito)lista[index];
           s += h.muestraHito();
        textoHUD.text = s;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            string s = "";
            index++;
            lista = gh.getHitos();
            h = (Hito)lista[index%lista.Count];
            s += h.muestraHito();
            textoHUD.text = s;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string s = "";
        index++;
        h = (Hito)lista[index];
        s += h.muestraHito();
        textoHUD.text = s;
    }
}
