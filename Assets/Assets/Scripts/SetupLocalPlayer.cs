using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<Movement>().enabled = true;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
