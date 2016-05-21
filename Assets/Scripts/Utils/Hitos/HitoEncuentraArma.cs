using UnityEngine;
using System.Collections;

public class HitoEncuentraArma : Hito {

    string arma;
    public HitoEncuentraArma(string arma)
    {
        this.arma = arma;
        texto = "consigue una " + arma;
    }

    public override bool compruebaHito(int dato, bool llegado, string arma)
    {
        if (this.arma == arma)
            return true;
        return false;
    }
}
