using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {


		//public Transform cloud; 
		public float speed = 5.0f;
	    float minFov = 5f;
	    float maxFov = 70f;
	    public float scrollSpeed = 10f;

		private Transform center;

		void Start() { 
			center = new GameObject().transform; 
			//center.parent = cloud; 
			center.position = Vector3.zero; 
			transform.parent = center; 
		}

		void Update() { 
			// if moves, uncomment the following line 
			 //center.position = cloud.position;

			if (Input.GetMouseButton(0))
			{
			var moveX = -Input.GetAxis ("Mouse Y") * speed;
			var moveY = Input.GetAxis ("Mouse X") * speed;

			if (transform.position.y < 15) {
				moveX = -moveX;
			}

			center.Rotate(moveX, moveY, 0.0f);
			}

		    float fov = Camera.main.fieldOfView;
		    fov -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
		    fov = Mathf.Clamp(fov, minFov, maxFov);
		    Camera.main.fieldOfView = fov;
		}

}