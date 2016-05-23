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
    void Start()
    {
        string s = "";
        index = 0;
        gh = game.GetComponent<GestorHitos>();
        lista = null;
        h = null;
        if (gh != null) { 
            lista = gh.getHitos();
            if (lista != null)
            {
                h = (Hito)lista[index];
                s += h.muestraHito();
                textoHUD.text = s;
            }
         }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (this.GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                string s = "";
                index++;
                lista = gh.getHitos();
                h = (Hito)lista[index % lista.Count];
                s += h.muestraHito();
                textoHUD.text = s;
            } 
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
