using UnityEngine;
using System.Collections;

public class HitoArmas : Hito {

    int numArmas;
    public HitoArmas(int numArmas)
    {
        this.numArmas = numArmas;
        texto = "consigue " + numArmas + " armas distintas";
    }

    public override bool compruebaHito(int dato, bool llegado, string arma)
    {
        numArmas -= dato;
        if (numArmas <= 0)
            return true;
        return false;
    }


    public override void recompensaHito()
    {

    }
}
