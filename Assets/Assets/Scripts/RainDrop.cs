using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour {

	private void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "TileSpace" || col.gameObject.tag == "WaterTile")
		  Destroy(gameObject);

		if(col.gameObject.tag == "FireTile")
		{
			var hit = col.gameObject;
			var health = hit.GetComponent<Health> ();
			if (health != null) {
				health.TakeDamage (10);
			} else {
				Debug.LogError ("var health null in RainDrop.cs");
			}
			Destroy (gameObject);
		}
	}
}
