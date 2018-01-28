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
		StartCoroutine(EnviromentBehaviour());		
	}

	public void SetCurrentContex(int indexContext){
		if(indexContext == 0)
			currentContext = context.lobby;
		else if(indexContext == 1)
			currentContext = context.gameplay;
		else
			currentContext = context.losing;
		mainAudioSource.loop = false;
	}

	IEnumerator WhilePro(){
		yield return new WaitForSeconds(1);
		while (true)
		{
			if(currentContext == context.lobby && !mainAudioSource.isPlaying){
				if(mainAudioSource.clip != lobbyLoop){
					mainAudioSource.clip = lobbyLoop;
					mainAudioSource.loop = true;
				}
				mainAudioSource.Play();
			}else if(currentContext == context.gameplay && !mainAudioSource.isPlaying){
				if(mainAudioSource.clip != gameplay1 && mainAudioSource.clip != gameplay2){
					mainAudioSource.clip = gameplay1;
					
				}else if(mainAudioSource.clip == gameplay1){
					mainAudioSource.clip = gameplay2;
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
	IEnumerator EnviromentBehaviour(){
		if(UnityEngine.Random.Range(0,2) == 0 )
			AudioSystem.Instance.PlaySound("Carro");
		if(UnityEngine.Random.Range(0,2) == 0 )
			AudioSystem.Instance.PlaySound("Hoja");
		if(UnityEngine.Random.Range(0,2) == 0 )
			AudioSystem.Instance.PlaySound("Radio");
		if(UnityEngine.Random.Range(0,2) == 0 )
			AudioSystem.Instance.PlaySound("Telefono");

		yield return new WaitForSeconds(UnityEngine.Random.Range(10,15));
		StartCoroutine(EnviromentBehaviour());
	}
}
