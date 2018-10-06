using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{

	public Camera camera;
	
	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Object entered");
		other.gameObject.transform.rotation *= Quaternion.Euler(0, 90, 0);
		camera.transform.eulerAngles = Vector3.Lerp(camera.transform.eulerAngles, new Vector3(270, 0, 0), 100);
	}

	void OnTriggerStay(Collider other)
	{
		
	}

	void OnTriggerExit(Collider other)
	{
		
	}
}
