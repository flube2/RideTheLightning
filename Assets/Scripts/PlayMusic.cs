﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {

	//public bool playing;
	//public AudioSource track1;

	private static PlayMusic instance = null;
	public static PlayMusic Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;


		}
		DontDestroyOnLoad(this.gameObject);
	}


}