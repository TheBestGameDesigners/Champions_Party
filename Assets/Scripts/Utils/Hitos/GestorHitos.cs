using UnityEngine;
using System.Collections;

public class GestorHitos : MonoBehaviour {


    ArrayList listaHitos;
	// Use this for initialization
	void Start () {
        listaHitos = new ArrayList();
        listaHitos.Add(new HitoArmas(10));
        listaHitos.Add(new HitoMuertes(30));
        listaHitos.Add(new HitoEncuentraArma("pistola"));
    }

    public ArrayList compruebaHitos(int dato, bool llegado, string arma)
    {
        ArrayList lista = new ArrayList();
        foreach(Hito h in listaHitos)
        {
            if (h.compruebaHito(dato, llegado, arma))
                lista.Add(h);
        }
        return lista;
    }

    public ArrayList getHitos()
    {
        return listaHitos;
    }
}
