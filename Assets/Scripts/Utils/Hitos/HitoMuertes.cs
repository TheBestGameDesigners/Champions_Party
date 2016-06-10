using UnityEngine;
using UnityEngine.UI;
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
        texto = "debes matar " + numMuertes + " enemigos";
        if (numMuertes <= 0)
            return true;
        return false;
    }

    public override void recompensaHito()
    {
        GameObject.FindGameObjectsWithTag("HUD")[0].transform.Find("Text").GetComponent<Text>().text = "Hito de muertes conseguido!!";
        Manager.m.healthPlayer = 100;
        if (GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerShooting>().currentWeapon != null)
        {
            GameObject weapon = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerShooting>().currentWeapon;
            if (weapon != null)
            {
                weapon.GetComponent<Weapon>().numBullet += 500;
                // Destroy(gameObject);
            }
        }
    }


}
