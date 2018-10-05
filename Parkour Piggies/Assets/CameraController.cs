using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		var mapObject = GameObject.FindWithTag("map");
		Vector3 mapCenter = mapObject.transform.position;
		transform.LookAt(mapCenter);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
