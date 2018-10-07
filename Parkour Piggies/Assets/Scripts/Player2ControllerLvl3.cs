using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player2ControllerLvl3 : PlayerController
{
    int maxHealth = 10;
    int startHealth;
    int currHealth;

    public GameObject[] carrots;

    CharacterController cc;
    private Vector3 moveDirection;


    private int doubleJumpCount;



    void Start()
    {
        startHealth = maxHealth;
        currHealth = startHealth;

        cc = GetComponent<CharacterController>();

        moveDirection.y = fallSpeed;
    }

    void Update()
    {
        if (cc.transform.position.y < 0)
        {
            RemoveHealth();
            Teleport();
        }

        if (cc.transform.position.x > -40 && cc.transform.position.x < 40 && cc.transform.position.z > -40 && cc.transform.position.z > -40 && cc.transform.position.y < 14) {
            RemoveHealth();
            Teleport();
        }

        WalkHandler();

        JumpHandler();

        cc.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.tag == "ToLevel2")
        {
            SceneManager.LoadScene(2);
        }
    }

    void Teleport()
    {
        cc.transform.position = exit.transform.position;
        cc.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        camera.offset = new Vector3(25.2F, -5F, 0.4F);
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

    void AddHealth()
    {
        currHealth += 1;

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

        if (currHealth > 10) RemoveHealth();
    }

    void WalkHandler()
    {
        float yStore = moveDirection.y;
        moveDirection = transform.forward * Input.GetAxis("P2_Vertical") +
                        transform.right * Input.GetAxis("P2_Horizontal");
        moveDirection = moveDirection.normalized * walkSpeed;
        moveDirection.y = yStore;
    }

    void JumpHandler()
    {

        if (cc.isGrounded)
        {
            doubleJumpCount = 0;
            moveDirection.y = -0.5f;
        }


        if (Input.GetButtonDown("P2_Jump") && doubleJumpCount < 2)
        {
            moveDirection.y = lowJumpSpeed;
            doubleJumpCount += 1;
        }

        if (moveDirection.y < 0)
        {
            moveDirection.y = moveDirection.y + Physics.gravity.y * (fallSpeed - 1) * Time.deltaTime;
        } else if (moveDirection.y > 0 && !Input.GetButtonDown("P2_Jump"))
        {
            moveDirection.y = moveDirection.y + Physics.gravity.y * (fallSpeed - 1) * Time.deltaTime;
        }



    }
}
