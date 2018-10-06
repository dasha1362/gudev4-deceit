using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1Controller : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	

	public float rotateSpeed;

	public Transform pivot;
	

	// Use this for initialization
	void Start ()
	{
//		offset = target.position - transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		
		transform.position = target.position - offset;
//		transform.rotation = Quaternion.Euler(target.rotation.x, 120, target.rotation.z);
		transform.LookAt(target);
	}
}
