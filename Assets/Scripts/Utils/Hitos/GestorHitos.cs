using UnityEngine;
using System.Collections;

public class GestorHitos : MonoBehaviour {


    ArrayList listaHitos;
    int numEnemies = 30;
	// Use this for initialization

    void awake()
    {
        listaHitos = new ArrayList();
    }
	void Start () {
        listaHitos = new ArrayList();
       //listaHitos.Add(new HitoArmas(10));
        listaHitos.Add(new HitoMuertes(numEnemies));
        listaHitos.Add(new HitoTrofeo());

        // listaHitos.Add(new HitoEncuentraArma("pistola"));
    }

    public void compruebaHitos(int dato, bool llegado, string arma)
    {
        foreach(Hito h in listaHitos)
        {
            if (h.compruebaHito(dato, llegado, arma))
            {
                h.recompensaHito();
                listaHitos.Remove(h);
                numEnemies *= 2;
                listaHitos.Add(new HitoMuertes(numEnemies));
            }
               
        }
    }

    public ArrayList getHitos()
    {
        return listaHitos;
    }
}
