using UnityEngine;
using System.Collections;

public class pointSpawn : MonoBehaviour {


    public bool visible;
	// Use this for initialization
	void Start () {
        visible = true;
	}

   void OnBecameVisible()
    {
        visible = true;
    }

    void OnBecameInvisible()
    {
        visible = false;
    }

}
