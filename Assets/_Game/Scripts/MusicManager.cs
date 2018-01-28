using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour {
	public static MusicManager instance;
	AudioSource mainAudioSource;
	public AudioClip lobbyIntro,lobbyLoop,gameplay1,gameplay2,losing;

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
		//mainAudioSource.SetScheduledEndTime(17.45);
		StartCoroutine(WhilePro());
	}

	public void SetCurrentContex(int indexContext){
		if(indexContext == 0)
			currentContext = context.lobby;
		else if(indexContext == 1)
			currentContext = context.gameplay;
		else
			currentContext = context.losing;
	}

	IEnumerator WhilePro(){
		yield return new WaitForSeconds(1);
		while (true)
		{
			if(currentContext == context.lobby && !mainAudioSource.isPlaying){
				if(mainAudioSource.clip != lobbyLoop){
					mainAudioSource.clip = lobbyLoop;
					
				}
				mainAudioSource.Play();
			}else if(currentContext == context.gameplay && !mainAudioSource.isPlaying){
				if(mainAudioSource.clip != gameplay1){
					mainAudioSource.clip = gameplay1;
					
				}
				mainAudioSource.Play();
			}else if(currentContext == context.losing && !mainAudioSource.isPlaying){
				if(mainAudioSource.clip != losing){
					mainAudioSource.clip = losing;
					
				}
				mainAudioSource.Play();
			} 
			yield return null;
		}
	}
	
}
