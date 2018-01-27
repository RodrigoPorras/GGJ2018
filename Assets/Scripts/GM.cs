using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	public static GM instance;

	void Awake () {
		if(instance == null){
			instance = this;
		}else{
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
