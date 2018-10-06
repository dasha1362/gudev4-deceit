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

    private int maxHealth = 10;
    private int startHealth;
    private int currHealth;

    public GameObject[] carrots;
    public GameObject exit;

    CharacterController cc;
    private Vector3 moveDirection;

    void Start()
    {
        startHealth = maxHealth;
        currHealth = startHealth;

        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (cc.transform.position.y < 0)
        {
            RemoveHealth();
            Teleport();
        }

        WalkHandler();

        JumpHandler();

        cc.Move(moveDirection * Time.deltaTime);
    }

    void Teleport()
    {
        cc.transform.position = exit.transform.position;
    }

    void RemoveHealth()
    {
        currHealth -= 1;
        // if (currHealth == -1) end game

        carrots[0].SetActive(currHealth >= 1);
        carrots[1].SetActive(currHealth >= 2);
        carrots[2].SetActive(currHealth >= 3);
        carrots[3].SetActive(currHealth >= 4);
        carrots[4].SetActive(currHealth >= 5);
        carrots[5].SetActive(currHealth >= 6);
        carrots[6].SetActive(currHealth >= 7);
        carrots[7].SetActive(currHealth >= 8);
        carrots[8].SetActive(currHealth >= 9);
        carrots[9].SetActive(currHealth == 10);

        if (currHealth > 10) currHealth = 10;
    }

    void WalkHandler()
    {
        moveDirection = new Vector3(Input.GetAxis("P2_Horizontal") * walkSpeed, moveDirection.y, Input.GetAxis("P2_Vertical") * walkSpeed);
    }

    void JumpHandler()
    {
        if (cc.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("P2_Jump"))
            {
                moveDirection.y = jumpSpeed;    
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
    }
}