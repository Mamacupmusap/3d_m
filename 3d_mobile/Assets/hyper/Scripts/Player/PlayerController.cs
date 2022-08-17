using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private float currentSpeed;
    private float playerSpeed = 3.0f;
    private float runSpeed = 5.0f;
    private float jumpHeight = 0.5f;
    private float gravity = -9.81f;

    public bool isGround = true;

    //Input
    private float forwardInput;
    private float horizontalInput;
    private bool jumpInput;

    //Ani
    private Animator animator;

    void Start()
    {
        currentSpeed = playerSpeed;

        //controller = gameObject.AddComponent<CharacterController>();
        controller = gameObject.GetComponent<CharacterController>();
        controller.center = new Vector3(0, 1, 0);

        animator = GetComponent<Animator>();
        
    }

   
    void Update()
    {
        //Input
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");

        //Check isGround
        isGround = controller.isGrounded;
        if(isGround && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //walking
        Vector3 move = new Vector3(forwardInput, 0, -horizontalInput);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if(move!= Vector3.zero)
        {
            animator.SetBool("walking", true);
            gameObject.transform.forward = move;
        }
        else
        {
            animator.SetBool("walking", false);
        }

        //running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("running", true);
            currentSpeed = runSpeed;
        }
        else
        {
            animator.SetBool("running", false);
            currentSpeed = playerSpeed;
        }

        //jumping
        if (jumpInput && isGround) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -10.0f * gravity);
            animator.SetBool("jumping", true);
        }
        else
        {
            animator.SetBool("jumping", false);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }


}
