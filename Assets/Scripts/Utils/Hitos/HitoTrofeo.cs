using UnityEngine;
using System.Collections;

public class HitoTrofeo : Hito
{

    public HitoTrofeo()
    {
        texto = "Encuentra el preciado trofeo";
    }

    public override bool compruebaHito(int dato, bool llegado, string arma)
    {
        return false;
    }

    public override void recompensaHito()
    {
    }


}

