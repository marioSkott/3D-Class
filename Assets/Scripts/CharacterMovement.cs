using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class CharacterMovement : MonoBehaviour
{

    
    PlayerMovement playerControls;
    public Transform player;
    [SerializeField] private float walkSpeed = 0.4f;
    public float jumpForce = 15f;
    private float jumpForceProxy;
    public LayerMask layerMask;
    public float groundOffset = 0.01f;
    public bool groundedPlayer;
    public bool moving;
    public Rigidbody rb;

    public Vector2 movementInput;
    public float jumpControl;


    private float sprintInput;

    private float moveSpeed;
    private bool jumpPressed = false;


    public float jumpInput;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerMovement();
            playerControls.Movement.walk.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            playerControls.Movement.jump.performed += ctx => jumpInput = ctx.ReadValue<float>();
            playerControls.Movement.run.performed += ctx => sprintInput = ctx.ReadValue<float>();
            playerControls.Enable();
        }
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }


    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // giving movespeed and jumpspeed here

        if (movementInput != Vector2.zero && sprintInput != 0f)
        {
            moveSpeed = walkSpeed + 1;
            jumpForceProxy = jumpForce * 10f;
        }
        else
        {
            moveSpeed = walkSpeed;
            jumpForceProxy = jumpForce * 5f;
        }

        // checking if player is grounded


        groundedPlayer = Physics.Raycast(player.position, Vector3.down, groundOffset, layerMask);
        //groundcheck but with sphere
        //groundedPlayer = Physics.CheckSphere(player.position, groundOffset, layerMask);

        //jumping if grounded and jumpinput is triggerd else jump input is discarded.
        if (jumpInput == 1f && groundedPlayer)
        {
            //Debug.Log(jumpPressed);
            if (jumpPressed)
            {
                rb.AddForce(0, jumpForceProxy, 0);
                Debug.Log("jumpVelocity");
                Debug.Log(jumpForceProxy);
                jumpPressed = false;
            }
            jumpPressed = false;
        }
        else
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        //run here or die
        Vector3 movePosition = transform.right * movementInput.x * moveSpeed + transform.forward * movementInput.y * moveSpeed;
        Vector3 newMovePosition = new Vector3(movePosition.x, rb.velocity.y, movePosition.z);
        rb.velocity = newMovePosition;

        //stopping the player completely if the move key is released except for the vertical velocity which will be taken care by gravity
        if (movementInput == Vector2.zero)
        {
            //can do maybe smooth decelerate here if need 
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            moving = false;
        }
        else
        {
            // Debug.Log(rb.velocity);
            moving = true;
        }
    }
}
