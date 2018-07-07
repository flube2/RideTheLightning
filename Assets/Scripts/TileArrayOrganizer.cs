using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

public class TileArrayOrganizer : NetworkBehaviour {

	// Use this for initialization
	public GameObject[,] allTileArr;

	void spawnWater(){
		Renderer rend;
		int xtileIndex = ((int)UnityEngine.Random.Range(0, 8));
        int ytileIndex = ((int)UnityEngine.Random.Range(0, 8));
        GameObject waterTile = allTileArr [xtileIndex, ytileIndex];
		if (waterTile.transform.position.y < 0) {
			rend = waterTile.GetComponent<Renderer> ();
			waterTile.tag = "WaterTile";
			rend.material.color = Color.blue;
			GameObject lightGameObject = new GameObject("Water Illumination");
			Light lightComp = lightGameObject.AddComponent<Light>();
			lightComp.color = Color.blue;
			lightComp.intensity = 20;
			lightComp.range = 12;
			lightGameObject.transform.position = waterTile.transform.position;
			//rend.material.shader = Shader.Find ("Reflective");

		} else
			spawnWater ();
		return;
	}

	void Start () {
        allTileArr = new GameObject[8, 8];
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("TileSpace").OrderBy(obj => obj.name).ToArray();
        int tileCounter = 0;
        for (int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                allTileArr[i, j] = tiles[tileCounter];
                tileCounter++;
            }
        }
        spawnWater ();
		spawnWater ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
