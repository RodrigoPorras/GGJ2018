using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour {
	public static MusicManager instance;
	AudioSource mainAudioSource;
	public enum context
	{
		lobby,gameplay,losing
	}
	public context currentContext;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(this);

	}

	void Start()
	{
		mainAudioSource = this.GetComponent<AudioSource>();
		StartCoroutine(WhilePro());
		
	}

	void Update()
	{
		print(mainAudioSource.timeSamples/mainAudioSource.clip.frequency);
	}

	IEnumerator WhilePro(){
		while (currentContext == context.lobby)
		{
			yield return new WaitForSeconds(17.45f);
			mainAudioSource.time = 8.72f;
		}
		while (currentContext == context.gameplay)
		{
			yield return new WaitForSeconds(17.32f);
			mainAudioSource.time = 8.72f;
		}
	}
}
