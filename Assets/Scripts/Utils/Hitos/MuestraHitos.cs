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
    string s;
    // Use this for initialization
    void Awake()
    {
        s = "";
        index = 0;
        gh = game.GetComponent<GestorHitos>();
        lista = null;
        h = null;
    }
    void Start()
    {
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
        if (gh != null)
        {
            s = "";
            lista = gh.getHitos();
            h = (Hito)lista[index % lista.Count];
            s += h.muestraHito();
            textoHUD.text = s;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (this.GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                s = "";
                index++;
                lista = gh.getHitos();
                h = (Hito)lista[index % lista.Count];
                s += h.muestraHito();
                textoHUD.text = s;
            } 
        }
    }
}
