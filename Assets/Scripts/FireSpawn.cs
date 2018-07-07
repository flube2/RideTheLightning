using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class FireSpawn : NetworkBehaviour {

    public List<GameObject> fireArr = new List<GameObject>();
	public Material fireMaterial;
	public Material groundMaterial;
	public AudioSource ignition;
	public AudioClip ignite;
	private float timeInterval = 10;
	private GameObject[] tileArr;
	private GameObject[] smokeArr;
	public int currentHealth = 100;
	public int pointsPerFire = 10;
	public int score = 0;

	private AudioSource audioSource;

	// Update is called once per frame
	public void spawnFire(){
		Renderer rend;
		tileArr = GameObject.FindGameObjectsWithTag ("TileSpace");
		int tileIndex = ((int)UnityEngine.Random.Range(0, tileArr.Length));
		GameObject fireTile = tileArr [tileIndex];
		rend = fireTile.GetComponent<Renderer> ();
		fireTile.tag = "FireTile";
		fireTile.AddComponent<Health>();
		var bc = fireTile.GetComponent<BoxCollider> ();
		bc.isTrigger = true;
		fireTile.AddComponent<Rigidbody> ();
		var rb = fireTile.GetComponent<Rigidbody> ();
		rb.useGravity = false;
		//rend.material.mainTexture = Resources.Load ("FireMaterial") as Texture;
		rend.material.color = Color.red;
		fireArr.Add (fireTile);
		var fireVector = fireTile.transform.position;


		GameObject newFireInstance =
			Instantiate(Resources.Load("FirePrefab"),
				new Vector3(fireVector.x, fireVector.y, fireVector.z),
				Quaternion.Euler(270, 0, 0)) as GameObject;
		newFireInstance.tag = "FirePrefab";

        GameObject newSmokeInstance = Instantiate(Resources.Load("WhiteSmoke"),
            new Vector3(fireVector.x, fireVector.y, fireVector.z),
                Quaternion.Euler(270, 0, 0)) as GameObject;
		newSmokeInstance.tag = "WhiteSmoke";
		GameObject lightGameObject = new GameObject("Fire Illumination");
		lightGameObject.tag = "FireIllumination";
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = Color.red;
		lightComp.intensity = 50;
		lightComp.range = 12;
		lightGameObject.transform.position = fireVector;

        newSmokeInstance.transform.localScale = newSmokeInstance.transform.localScale / 2;

	}




	GameObject GetClosestObject(string tag)
	{
		var objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
		GameObject closestObject = null;
		foreach (var obj  in objectsWithTag)
		{
			if(closestObject == null)
			{
				closestObject = obj;
			}
			//compares distances
			if(Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closestObject.transform.position))
			{
				closestObject = obj;
			}
		}
		return closestObject;
	}



    public void destroyFire(GameObject tile)
    {
		Renderer rend = tile.GetComponent<Renderer> ();
        tile.tag = "Untagged";
		rend.material = groundMaterial;
		GameObject smoke = GetClosestObject ("WhiteSmoke");
		Destroy (smoke);
		GameObject fire = GetClosestObject ("FirePrefab");
		Destroy (fire);
		GameObject illum = GetClosestObject ("FireIllumination");
		Destroy (illum);
        fireArr.Remove(tile);
		score += pointsPerFire;
    }

	/*public void TakeDamage(int amount)
	{
		if (!isServer)
			return;

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			GameObject go = GetClosestObject ("FireTile");
			destroyFire(go);
		}
	}*/




	void Awake() {
		audioSource = GetComponent<AudioSource> ();
	}

	void Start (){
		audioSource.Play ();
		spawnFire ();
	}
	void Update () {
		timeInterval -= Time.deltaTime;
		//Debug.Log (timeInterval);
		if (timeInterval < 0) {
			timeInterval = 10;
			spawnFire();
			 //var go = GameObject.FindGameObjectWithTag ("FireTile");
			//destroyFire (go);
		}


	}
}
