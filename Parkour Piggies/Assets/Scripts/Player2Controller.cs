using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player2Controller : MonoBehaviour
{

    public float walkSpeed;
    public float jumpSpeed;
    public float gravityScale;
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
        moveDirection = new Vector3(Input.GetAxis("P2_Horizontal") * walkSpeed, moveDirection.y, Input.GetAxis("P2_Vertical") * walkSpeed);
    }

    void JumpHandler()
    {
        if (cc.isGrounded && Input.GetButtonDown("P2_Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
    }
}