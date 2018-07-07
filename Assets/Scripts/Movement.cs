using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement : NetworkBehaviour {


    public int currentHeight = 0;
	public int rainDropCounter = 0; 
	public int numRainDropsPerAction; 
    public Actions actions;
    public GameObject rainDrop;
    public GameObject cloud; 
	private GameObject cPanel;
	private float controlPanelActive = 0f;
	private bool playing = false;
	public int winLimit = 1000;

    Vector3 origPos;

    public void resetPosition()
    {
        GameObject.FindGameObjectWithTag("PlayerCloud").transform.position = origPos;
    }

	 //Use this for initialization
	void Start () {
		cPanel = GameObject.FindGameObjectWithTag("ControlsPanel");	
		//Debug.Log ("Cpanel is: ");
		//Debug.Log (cPanel);
        if (isLocalPlayer)
        {
            GetComponentInChildren<WaterInteraction>().enabled = true;
        }
	}


	// Update is called once per frame
void Update () {
		if (!isLocalPlayer) {
			return;
		}


		var holder = GameObject.FindGameObjectWithTag ("Respawn");
		var script = holder.GetComponent<FireSpawn> ();
		int score = script.score;
		if (score >= winLimit) {
			SceneManager.LoadScene("ClosingCredits");
		}

        if(actions.currNumberofActions == 4)
        {
            origPos = cloud.transform.position;
        }
        if (actions.canDoStuff)
        {
            Vector3 currentPos = cloud.transform.position;
            //Debug.Log(currentPos);
			if (Input.GetKeyDown(KeyCode.W) && (currentPos.x > -40))
            {
                currentPos += new Vector3(-11.2f, 0, 0);
                actions.currNumberofActions--;
				//move1.Play ();
            }
			if (Input.GetKeyDown(KeyCode.S) && (currentPos.x < 45))
            {
                currentPos += new Vector3(11.2f, 0, 0);
                actions.currNumberofActions--;
				//Debug.Log (currentPos);
				//move1.Play ();
            }

			if (Input.GetKeyDown(KeyCode.A) && (currentPos.z > -50))
            {
                currentPos += new Vector3(0, 0, -11.7f);
                actions.currNumberofActions--;
				//move2.Play ();
            }
			if (Input.GetKeyDown(KeyCode.D) && (currentPos.z < 40))
            {
                currentPos += new Vector3(0, 0, 11.7f);
				//Debug.Log (currentPos.z);
                actions.currNumberofActions--;
				//move2.Play ();
            }

			if (Input.GetButtonDown("Fire1")){
				
				GameObject cloud = GameObject.Find("Cloud");
				WaterInteraction cloudscript = cloud.GetComponent<WaterInteraction>();
				int curWater = cloudscript.waterCounter;

				if (curWater > 0) {

					GameObject newRainDrop = GameObject.Instantiate (rainDrop, cloud.transform.position, cloud.transform.rotation) as GameObject;	

					//Debug.Log ("rain");
					GameObject lightGameObject = new GameObject ("Lightning");
					Light lightComp = lightGameObject.AddComponent<Light> ();
					lightComp.color = Color.yellow;
					lightComp.intensity = 100;
					lightComp.range = 20;
					//thunder.Play();
					lightGameObject.transform.position = new Vector3 (currentPos.x, currentPos.y - 3, currentPos.z);
					Destroy (lightGameObject, 0.5f);
					if (numRainDropsPerAction == rainDropCounter) {
						actions.currNumberofActions--;
					} else {
						++rainDropCounter;
					}
				}
		}
			if (currentHeight < 3)
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					currentPos += new Vector3 (0, 11.7f, 0);
					currentHeight++;
                    actions.currNumberofActions--;
                }
			if(currentHeight > 0)
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					currentPos += new Vector3 (0, -11.7f, 0);
					currentHeight--;
                    actions.currNumberofActions--;
                }


			if (Input.GetKeyDown(KeyCode.Escape)) {
				SceneManager.LoadScene("SureQuit");
			}

			if(Input.GetKeyDown(KeyCode.PageUp))
				SceneManager.LoadScene ("Title", LoadSceneMode.Single);

			if (Input.GetKeyDown(KeyCode.Tab)) {
				GameObject go = GameObject.FindGameObjectWithTag ("song");
				AudioSource a = go.GetComponent<AudioSource> ();
				if (playing == false) {
					//a.enabled = playing;
					a.Pause ();
				} else {
					a.UnPause ();
				}
				playing = !playing;
			}


			if (Input.GetKeyDown (KeyCode.C)) {
				if (controlPanelActive == 0f)
					controlPanelActive = 1f;
				else
					controlPanelActive = 0f;


				cPanel.GetComponent<CanvasGroup>().alpha = controlPanelActive;
			}

            cloud.transform.position = currentPos;
        }
	}
}
