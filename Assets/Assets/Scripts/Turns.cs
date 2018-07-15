using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour {
    public int currTurn;
    
	// Use this for initialization
	void Start () {
        currTurn = 0;

		GameObject tileHold = GameObject.Find("TileHolder");
		FireSpawn fireScript = tileHold.GetComponent<FireSpawn>();

		fireScript.spawnFire();
	}

    public void nextTurn()
    {
        currTurn++;

		GameObject tileHold = GameObject.Find("TileHolder");
        GameObject cloud = GameObject.Find("Cloud");
        GameObject cloudai = GameObject.Find("AIRoot");

        CloudAI AIscirpt = cloudai.GetComponent<CloudAI>();
		Actions cloudactionscript = cloud.GetComponent<Actions>();
		FireSpawn fireScript = tileHold.GetComponent<FireSpawn>();

        AIscirpt.StartTurn();
        cloudactionscript.currNumberofActions = 4;
		if (currTurn % 2 == 0) {
			fireScript.spawnFire();
		}
    }	
}
