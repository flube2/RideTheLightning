using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnReturnKey : MonoBehaviour {

	public string sceneToLoad;
	public string prevScene;
	private bool playing = true;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return))
			SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);
		
		if(Input.GetKeyDown(KeyCode.PageUp))
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
