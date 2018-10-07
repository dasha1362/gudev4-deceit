using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player1Controller : PlayerController
{
    private int maxHealth = 10;
    private int startHealth;
    private int currHealth;

    public GameObject[] carrots;


    CharacterController cc;
    private Vector3 moveDirection;

	private AudioSource oink;

    void Start()
    {
        startHealth = maxHealth;
        currHealth = startHealth;

        cc = GetComponent<CharacterController>();
		oink = GetComponent<AudioSource> ();
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

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.tag == "CollectCarrot2")
        {
            Destroy(collision.gameObject);
            AddHealth();
        }
    }

    void Teleport()
    {
        
        cc.transform.position = exit.transform.position;
        cc.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        camera.offset = new Vector3(25.2F, -5F, 0.4F);
		oink.Play (0);
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