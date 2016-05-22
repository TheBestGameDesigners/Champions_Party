using UnityEngine;
using System.Collections;

public class StopMusic : MonoBehaviour {

    public void OnGUI()
    {
        if (GUI.Button(new Rect(245, -133, 160, 30), "Button"))
        {
            AudioListener.volume = 1 - AudioListener.volume;
        }
    }
}
