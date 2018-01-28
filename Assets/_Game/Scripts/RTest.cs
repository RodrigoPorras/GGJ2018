using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTest : MonoBehaviour {
	AudioSource myAudioSource;

	void Start()
	{
		myAudioSource = this.GetComponent<AudioSource>();
	}

	void Update()
	{
		if((int)myAudioSource.time == 2){
			myAudioSource.time = 0;
		}
	}
}
