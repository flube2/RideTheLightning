﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboards : MonoBehaviour {

	//public Camera m_Camera;

	void Update()
	{
		transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
			Camera.main.transform.rotation * Vector3.up);
	}
}
