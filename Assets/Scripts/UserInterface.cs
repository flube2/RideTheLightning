using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {
    public Text firetext;
    public Text watertext;
    public Text waterammotext;
    public Text actiontext;
    public Text turntext;
	public Text scoretext;
	//public GameObject controls;

    public void resetCloud()
    {
        GameObject cloud = GameObject.Find("Cloud");
        WaterInteraction cloudscript = cloud.GetComponent<WaterInteraction>();
        Movement cloudmovementscript = cloud.GetComponent<Movement>();
        Actions cloudactionscript = cloud.GetComponent<Actions>();

        cloudscript.resetWaterCounter();
        cloudmovementscript.resetPosition();
        cloudactionscript.ResetActions();
    }

	// Update is called once per frame
	void Update () {

        GameObject tiles = GameObject.Find("TileHolder");
        FireSpawn firescript = tiles.GetComponent<FireSpawn>();
        var lenOfFire = firescript.fireArr.Count;
		var score = firescript.score;
        firetext.text = "Fires Burning: " + lenOfFire;
        GameObject[] waterArray = GameObject.FindGameObjectsWithTag("WaterTile");
        var lenOfWater = waterArray.Length;
        watertext.text = "Water Available: " + lenOfWater;
		scoretext.text = "Score: " + score;
		scoretext.color = Color.white;

        GameObject cloud = GameObject.Find("Cloud");
        if(cloud == null)
        {
            waterammotext.text = "Current Water:";
        }
        else
        {
            WaterInteraction cloudscript = cloud.GetComponent<WaterInteraction>();
            waterammotext.text = "Current Water: " + cloudscript.waterCounter;
            Actions cloudactionscript = cloud.GetComponent<Actions>();
            actiontext.text = "Actions Remaining: " + cloudactionscript.currNumberofActions;



			if (lenOfFire >= 0 && lenOfFire <= 4)
				firetext.color = Color.green;
			else if (lenOfFire > 4 && lenOfFire <= 10)
				firetext.color = Color.yellow;
			else
				firetext.color = Color.red;

			if (lenOfWater == 0)
				watertext.color = Color.red;
			else if (lenOfWater == 1)
				watertext.color = Color.yellow;
			else
				watertext.color = Color.green;


			if (cloudscript.waterCounter >= 0 && cloudscript.waterCounter <= 5)
				waterammotext.color = Color.red;
			else if (cloudscript.waterCounter > 5 && cloudscript.waterCounter <= 10)
				waterammotext.color = Color.yellow;
			else
				waterammotext.color = Color.green;


			if (cloudactionscript.currNumberofActions >= 0 && cloudactionscript.currNumberofActions <= 10)
				actiontext.color = Color.red;
			else if (cloudactionscript.currNumberofActions > 10 && cloudactionscript.currNumberofActions <= 50)
				actiontext.color = Color.yellow;
			else
				actiontext.color = Color.green;

        }
        GameObject plane = GameObject.Find("Plane");
        Turns turn = plane.GetComponent<Turns>();
        turntext.text = "Turn: " + turn.currTurn;
    }
}
