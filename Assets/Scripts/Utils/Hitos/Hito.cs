using UnityEngine;
using System.Collections;

public abstract class Hito{

    protected string texto;

    public Hito() { }
    public Hito(string texto)
    {
        this.texto = texto;
    }

    public abstract bool compruebaHito(int dato, bool llegado, string arma);

    public virtual string muestraHito() { return texto; }

}
