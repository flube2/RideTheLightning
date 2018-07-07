using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	public int delayTime;


	void Start () {

		StartCoroutine (delay());
	}






	IEnumerator delay()
	{

		yield return new WaitForSeconds (delayTime);
		Application.Quit();

	}



}
