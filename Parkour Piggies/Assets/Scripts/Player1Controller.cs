using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player1Controller : MonoBehaviour {

    public float walkSpeed = 8f;
    public float jumpSpeed = 10f;
    public float gravityScale = 0.25f;
    //flag to keep track of whether a jump started
    bool pressedJump = false;

    CharacterController cc;
    private Vector3 moveDirection;

    Rigidbody rb;
    Collider coll;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        WalkHandler();

        JumpHandler();

        cc.Move(moveDirection * Time.deltaTime);
    }

    void WalkHandler()
    {
        float yStore = moveDirection.y;
        moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveDirection = moveDirection.normalized * walkSpeed;
        moveDirection.y = yStore;
    }

    void JumpHandler()
    {
        if (cc.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;    
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
    }

}