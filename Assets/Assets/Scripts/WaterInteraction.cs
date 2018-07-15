using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WaterInteraction : NetworkBehaviour
{
    public int waterCounter = 0;
    public int origWater;
    public GameObject cloud;
    public Movement movement;
    private GameObject[] waterArr;
    private GameObject[] fireArray;
    public FireSpawn fscript;
    public Actions actions;

    void Start()
    {
        GameObject tiles = GameObject.Find("TileHolder");
        fscript = tiles.GetComponent<FireSpawn>();
        movement = GetComponentInParent<Movement>();
    }


    public void resetWaterCounter()
    {
        waterCounter = origWater;
    }

    // Update is called once per frame
    bool waterCheck()
    {
        Vector3 currentPos = movement.cloud.transform.position;
        waterArr = GameObject.FindGameObjectsWithTag("WaterTile");
        foreach (var vect in waterArr)
        {
            var waterDist = Vector3.Distance(currentPos, vect.transform.position);
            if (waterDist < 15)
            {
                actions.currNumberofActions--;
                return true;
            }
        }
        return false;
    }

    void Rain()
    {
        Renderer rend;
        Vector3 currentPos = GameObject.FindGameObjectWithTag("PlayerCloud").transform.position;
        fireArray = GameObject.FindGameObjectsWithTag("FireTile");
        /*GameObject lightGameObject = new GameObject("Lightning");
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = Color.yellow;
		lightComp.intensity = 100;
		lightComp.range = 20;
		lightGameObject.transform.position = new Vector3(currentPos.x, currentPos.y - 3, currentPos.z);
		Destroy(lightGameObject);*/

        foreach (var vect in fireArray)
        {
            var fireDist = Vector3.Distance(currentPos, vect.transform.position);
            if (fireDist < 15)
            {
                actions.currNumberofActions--;
                rend = vect.GetComponent<Renderer>();
                rend.material.color = Color.green;
                fscript.destroyFire(vect);
                Debug.Log("rain");
            }
        }

    }

    void Update()
    {
        if (actions.currNumberofActions == 4)
        {
            origWater = waterCounter;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (waterCheck() == true)
            {
                waterCounter++;
                Debug.Log(waterCounter);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (waterCounter > 0)
            {
                Rain();
                waterCounter--;
            }
        }
    }
}

