using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

    public AudioClip levelMusic;
    public AudioClip menuMusic;

    private AudioSource source;


	void Awake () {
        source = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded () {
        if(Application.loadedLevel == 0)
        {
            source.clip = menuMusic;
        }
        else source.clip = levelMusic;

        source.Play();
	}
}
