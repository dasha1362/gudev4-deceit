using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1Controller : MonoBehaviour {

	public Transform target;
	public Vector3 offset;


	public float rotateSpeed;
	
	
	
	// Use this for initialization
	void Start ()
	{
		offset = target.position - transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.PageDown))
		{
			target.Rotate(0, rotateSpeed, 0);	
		}
		
		transform.position = target.position - offset;
		
		transform.LookAt(target);
	}
}
