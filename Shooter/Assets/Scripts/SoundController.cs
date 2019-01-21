using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public AudioClip[] effectSounds;
    public AudioSource effectSource;
	// Use this for initialization
	void Start () {
		
	}

    public void PlayEffect(int id)
    {
        effectSource.PlayOneShot(effectSounds[id]);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
