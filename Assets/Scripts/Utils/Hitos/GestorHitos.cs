using UnityEngine;
using System.Collections;

public class GestorHitos : MonoBehaviour {


    ArrayList listaHitos;
	// Use this for initialization

    void awake()
    {
        listaHitos = new ArrayList();
    }
	void Start () {
        listaHitos = new ArrayList();
        listaHitos.Add(new HitoArmas(10));
        listaHitos.Add(new HitoMuertes(30));
        listaHitos.Add(new HitoEncuentraArma("pistola"));
    }

    public void compruebaHitos(int dato, bool llegado, string arma)
    {
        foreach(Hito h in listaHitos)
        {
            if (h.compruebaHito(dato, llegado, arma))
                listaHitos.Remove(h);  
        }
    }

    public ArrayList getHitos()
    {
        return listaHitos;
    }
}
