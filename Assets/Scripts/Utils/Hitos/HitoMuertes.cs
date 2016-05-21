using UnityEngine;
using System.Collections;

public class HitoMuertes : Hito {

    int numMuertes;
	public HitoMuertes(int numMuertes)
    {
        this.numMuertes = numMuertes;
        texto = "debes matar " + numMuertes + " enemigos";
    }

    public  override bool compruebaHito(int dato, bool llegado, string arma)
    {
        numMuertes -= dato;
        if (numMuertes <= 0)
            return true;
        return false;
    }


}
