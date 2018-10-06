using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    public Camera1Controller camera;
    public Vector3 newPosition;
    public int degreesToTurn;
    

    private Vector3 oldPosition;
    private float interpolation;
    private bool shouldUpdate = false;

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (camera.offset != newPosition)
        {
            other.gameObject.transform.rotation *= Quaternion.Euler(0, degreesToTurn, 0);
            oldPosition = camera.offset;
            interpolation = 0.01F;
            shouldUpdate = true;            
        }
    }

    void Update()
    {
        if (shouldUpdate && camera.offset != newPosition)
        {
            camera.offset = Vector3.Lerp(oldPosition, newPosition, interpolation);
            interpolation += 0.01F;
            if (camera.offset == newPosition)
            {
                shouldUpdate = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
    }

    void OnTriggerExit(Collider other)
    {
    }
}