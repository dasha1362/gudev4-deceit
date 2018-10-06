using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player1Controller : MonoBehaviour {

    public float walkSpeed = 8f;
    public float jumpSpeed = 80f;
    public float gravityScale = 0.05f;

    CharacterController cc;
    private Vector3 moveDirection;

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
        moveDirection  = new Vector3(Input.GetAxis("Horizontal") * walkSpeed, 0f, Input.GetAxis("Vertical") * walkSpeed);
    }

    void JumpHandler()
    {
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        moveDirection.y = moveDirection.y +  (Physics.gravity.y * gravityScale);
    }

}
