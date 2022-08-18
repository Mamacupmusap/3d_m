using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    Vector2 moveDirection = Vector2.zero;
    private float currentSpeed;
    private float playerSpeed = 3.0f;
    private float runSpeed = 5.0f;

    private Vector3 playerVelocity;
    private float jumpHeight = 0.5f;
    private float gravity = -9.81f;
    private bool isGround;
    private bool jumpPressed = false;


    //Input
    //private float forwardInput;
    //private float horizontalInput;
    //private bool jumpInput;

    public DefaultAction playercontrols;
    private InputAction Moving;
    private InputAction Running;
    private InputAction Jumping;

    //Ani
    private Animator animator;

    private void Awake()
    {
        playercontrols = new DefaultAction();
    }

    private void OnEnable()
    {
        //playercontrols.Enable();

        Moving = playercontrols.Player.Move;
        Running = playercontrols.Player.Run;
        Jumping = playercontrols.Player.Jump;

        Moving.Enable();
        Running.Enable();
        Jumping.Enable();
    }

    private void OnDisable()    
    {
        //playercontrols.Disable();
        Moving.Disable();
        Running.Disable();
        Jumping.Disable();
    }

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
        //action
        walk();
        run();
        jump();

    }
    void OnWalk() {
        moveDirection = Moving.ReadValue<Vector2>();
    }

    void walk() {

        //Input
        //forwardInput = Input.GetAxis("Vertical");
        //horizontalInput = Input.GetAxis("Horizontal");
        OnWalk();

        //Vector3 move = new Vector3(forwardInput, 0, -horizontalInput);
        Vector3 move = new Vector3(moveDirection.y, 0, -moveDirection.x);
        controller.Move(move * Time.deltaTime * currentSpeed);

        if (move != Vector3.zero)
        {
            animator.SetBool("walking", true);
            gameObject.transform.forward = move;
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void run()
    {
        bool isShiftKey = Running.ReadValue<float>() > 0.1f;
        if (isShiftKey)
        {
            animator.SetBool("running", true);
            currentSpeed = runSpeed;
        }
        else
        {
            animator.SetBool("running", false);
            currentSpeed = playerSpeed;
        }
    }

    void checkOnGround()
    {
        isGround = controller.isGrounded;
        if (isGround)
        {
            playerVelocity.y = 0f;
        }
    }

    void jumpp()
    {
        bool isSpaceKey = Jumping.ReadValue<float>() > 0.1f;
        if (isSpaceKey)
        {
            jumpPressed = true;
            animator.SetBool("jumping", true);
        }
        else {
            animator.SetBool("jumping", false);
        }
    } 

    void jump(){

        //Input
        //jumpPressed = Input.GetButtonDown("Jump");
        
        jumpp();
        checkOnGround();

        if(jumpPressed && isGround)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -10.0f * gravity);
            jumpPressed = false;
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
