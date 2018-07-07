using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Health : NetworkBehaviour {

	public const int maxHealth = 100;
	public bool destroyOnDeath = true;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;



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



	public void TakeDamage(int amount)
	{
		//if (!isServer)
			//return;

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Debug.Log ("Fire Out");
			if (destroyOnDeath)
			{
				GameObject fire = GetClosestObject ("FireTile");
				GameObject go = GetClosestObject ("Respawn");
				var delete = go.GetComponent<FireSpawn> ();
				delete.destroyFire (fire);
				//Destroy(gameObject);
			} 
			else
			{
				currentHealth = maxHealth;
			}
		}
	}

	void OnChangeHealth (int currentHealth )
	{
		//healthBar.sizeDelta = new Vector2(currentHealth , healthBar.sizeDelta.y);
		Debug.LogError("Awesome! Health Changed");
	}
		
}