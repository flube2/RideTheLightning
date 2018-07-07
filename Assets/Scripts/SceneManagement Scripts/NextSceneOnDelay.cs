using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnDelay : MonoBehaviour {
	public int delayTime;
	public string sceneToLoad;
	public string prevScene;
	private bool playing = true;

	void Start () {

		StartCoroutine (delay());
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
			SceneManager.LoadScene ("Lobby", LoadSceneMode.Single);
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




	IEnumerator delay()
	{

		yield return new WaitForSeconds (delayTime);
		SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);

	}
}
