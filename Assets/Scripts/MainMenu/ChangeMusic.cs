using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

    public AudioClip levelMusic;

    private AudioSource source;

	void Awake () {
        source = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded () {
        source.clip = levelMusic;
        source.Play();
	}
}
