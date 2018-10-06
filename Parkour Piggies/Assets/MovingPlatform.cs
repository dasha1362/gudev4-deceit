using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	
	public float speed;
	public bool movePositiveDirectionFirst;
	public float distance;
	public enum Axis{ x, y, z }
	public Axis axis;

	private bool movingPositiveDirection;

	private Vector3 target;

	void Start () {

		movingPositiveDirection = movePositiveDirectionFirst;

		target = transform.position;
		changeDirection ();

	}
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards (transform.position, target, step);

		switch (axis) {
		case Axis.x:
			if (transform.position.x == target.x) {
				changeDirection ();
			}
			break;
		case Axis.y:
			if (transform.position.y == target.y) {
				changeDirection ();
			}
			break;
		case Axis.z:
			if (transform.position.z == target.z) {
				changeDirection ();
			}
			break;
		default:
			Debug.Log("excuse me");
			break;
		}
		
	}

	void changeDirection() {
		if (movingPositiveDirection) {
			switch (axis) {
			case Axis.x:
				target.x += distance;
				break;
			case Axis.y:
				target.y += distance;
				break;
			case Axis.z:
				target.z += distance;
				break;
			default:
				Debug.Log("excuse me");
				break;
			}
		} else {
			switch (axis) {
			case Axis.x:
				target.x -= distance;
				break;
			case Axis.y:
				target.y -= distance;
				break;
			case Axis.z:
				target.z -= distance;
				break;
			default:
				Debug.Log("excuse me");
				break;
			}
		}
		movingPositiveDirection = !movingPositiveDirection;
	}
}
