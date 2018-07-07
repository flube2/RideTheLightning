using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SureQuit : MonoBehaviour {

	public string sceneToLoad;
	public string prevScene;
	private bool playing = false;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Y))
			SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);

		if(Input.GetKeyDown(KeyCode.PageUp) || Input.GetKeyDown(KeyCode.N))
			SceneManager.LoadScene (prevScene, LoadSceneMode.Single);

		if (Input.GetKeyDown(KeyCode.Tab)) {
			GameObject go = GameObject.FindGameObjectWithTag ("song");
			AudioSource a = go.GetComponent<AudioSource> ();
			if (playing == false) {
				//a.enabled = playing;
				a.Pause ();
			} else {
				a.UnPause ();
			}
			playing = !playing;
		}

	}

}
