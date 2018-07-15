using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnRain : MonoBehaviour {

	public AudioSource thunder;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		GameObject cloud = GameObject.Find("Cloud");
		WaterInteraction cloudscript = cloud.GetComponent<WaterInteraction>();
		int curWater = cloudscript.waterCounter;

		if (Input.GetKeyDown (KeyCode.F) && curWater > 0) {
			thunder.Play();
		}
	}
}