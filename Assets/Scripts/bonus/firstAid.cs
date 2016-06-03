using UnityEngine;
using System.Collections;

public class firstAid : MonoBehaviour {

    public int plusLife;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    public void FirstAid() {


        if ((Manager.m.healthPlayer + plusLife) > 100)
        {
            Manager.m.healthPlayer = 100;
           
        }
        else Manager.m.healthPlayer += plusLife; 
    }
}
