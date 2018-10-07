using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Camera1Controller : CameraController {

	public Transform target;
	

	void LateUpdate ()
	{
		transform.position = target.position - offset;
		transform.LookAt(target);
	}
}
