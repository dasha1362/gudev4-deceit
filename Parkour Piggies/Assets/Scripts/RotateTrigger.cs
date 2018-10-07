using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    public CameraController camera;
    public Vector3 newPosition;
    public int degreesToTurn;
    public String playerTag;

    private Vector3 oldPosition;
    private float interpolation;
    private bool shouldUpdate = false;
    

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag) && camera.offset != newPosition)
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