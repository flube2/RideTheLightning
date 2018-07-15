using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	public GameObject go;
	private bool active = false;
	// Use this for initialization
	void Start () {
		go = GameObject.FindGameObjectWithTag("ControlsPanel");	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			active = !active;
			go.gameObject.SetActive(active);
		}
	}
}
