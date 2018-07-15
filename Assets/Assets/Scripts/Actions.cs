using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {

    public int currNumberofActions;
    public bool canDoStuff;

    public void ResetActions()
    {
        currNumberofActions = 200;
    }

	// Use this for initialization
	void Start () {
        currNumberofActions = 200;
        canDoStuff = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (currNumberofActions == 0)
        {
            canDoStuff = false;
        }
        else
        {
            canDoStuff = true;
        }
	}
}
