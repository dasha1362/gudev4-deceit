using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour
{
    public int maxHearts = 10;
    public int startHearts = 10;
    public int currHearts;
    public Image[] healthImages;
    public Sprite[] healthSprites;

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
        currHearts = startHearts;
    }

    void Update()
    {
        WalkHandler();

        JumpHandler();

        cc.Move(moveDirection * Time.deltaTime);
    }

    void WalkHandler()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * walkSpeed, moveDirection.y, Input.GetAxis("Vertical") * walkSpeed);
    }

    void JumpHandler()
    {
        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
    }

}