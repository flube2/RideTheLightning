using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class CloudAI : MonoBehaviour {

    public const string WATERTILE = "WATER";
    public const string FIRETILE = "FIRE";

    Vector3 destination;
    private GameObject[] waterArr;
    private GameObject[] fireArr;
    private GameObject AI;

    private int currNumberOfActions;
    private int waterCounter;
    public int currentHeight = 0;
    public bool atDest;
    private string currDestinationType;
    FireSpawn fscript;

    // Use this for initialization
    void Start () {
        AI = GameObject.FindGameObjectWithTag("AI");
        currNumberOfActions = 4;
        waterCounter = 0;
        waterArr = GameObject.FindGameObjectsWithTag("WaterTile");
        atDest = false;
    }
	
    public void StartTurn()
    {
        fireArr = GameObject.FindGameObjectsWithTag("FireTile");
        var currPosition = GameObject.Find("AI Cloud").transform.position;
        if (destination != Vector3.zero)
        {
            findPath();
        }
        if(waterCounter == 0)
        {
            float dist = -1;
            foreach (var water in waterArr)
            {
               var currdist = Vector3.Distance(water.transform.position, currPosition);
               if(dist == -1)
                {
                    dist = currdist;
                    destination = water.transform.position;
                }
                else if(currdist <= dist)
                {
                    dist = currdist;
                    destination = water.transform.position;
                }
            }
            currDestinationType = WATERTILE;
            findPath();
        }
        else if(fireArr.Length > 0)
        {
            float dist = -1;
            foreach(var fire in fireArr)
            {
                var currdist = Vector3.Distance(fire.transform.position, currPosition);
                if (dist == -1)
                {
                    dist = currdist;
                    destination = fire.transform.position;
                }
                else if (currdist <= dist)
                {
                    dist = currdist;
                    destination = fire.transform.position;
                }
            }
            currDestinationType = FIRETILE;
            findPath();
        }
        else
        {
            float dist = -1;
            foreach (var water in waterArr)
            {
                var currdist = Vector3.Distance(water.transform.position, currPosition);
                if (dist == -1)
                {
                    dist = currdist;
                    destination = water.transform.position;
                }
                else if (currdist <= dist)
                {
                    dist = currdist;
                    destination = water.transform.position;
                }
            }
            currDestinationType = WATERTILE;
            findPath();
        }
        currNumberOfActions = 4;//reset the actions since its the end of the ai turn
    }
    
    private void findPath()
    {
        AI = GameObject.FindGameObjectWithTag("AI");
        Vector3 currPosition = AI.transform.position;
        while (currNumberOfActions != 0)
        {
            var currdist = Vector3.Distance(destination, currPosition);
            if (currdist < 15)
            {
                destination = Vector3.zero;
                if(currDestinationType == WATERTILE)
                {
                    waterCounter++;
                    currNumberOfActions--;
                }
                else
                {
                    Rain();
                }
            }
            else
            {
                Vector3 direction = closest();
                if(direction == Vector3.forward)
                {
                    currPosition += new Vector3(11.2f, 0, 0);
                }
                else if(direction == Vector3.back)
                {
                    currPosition += new Vector3(-11.2f, 0, 0);
                }
                else if (direction == Vector3.left)
                {
                    currPosition += new Vector3(0, 0, -11.7f);
                }
                else
                {
                    currPosition += new Vector3(0, 0, 11.7f);
                }
                AI.transform.position = currPosition;
                currNumberOfActions--;
            }
        }
    }
    private Vector3 closest()
    {
        Vector3[] directions = {Vector3.forward,
                              Vector3.back,
                              Vector3.left,
                              Vector3.right};
        Vector3 closest =
           (from dir in directions
            orderby Vector3.Distance(transform.position + dir, destination) ascending
            select dir).First();
        return closest;
    }

    private void Rain()
    {
        Vector3 currPosition = AI.transform.position;
        Renderer rend;
        foreach (var vect in fireArr)
        {
            var fireDist = Vector3.Distance(currPosition, vect.transform.position);
            if (fireDist < 15)
            {
                currNumberOfActions--;
                rend = vect.GetComponent<Renderer>();
                rend.material.color = Color.green;
                fscript.destroyFire(vect);
                Debug.Log("rain");
            }
        }
    }
    
}
