using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemen : MonoBehaviour
{
    [Header("movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float JumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("keybinds")]
    public KeyCode jumpkey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerheight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerheight * 0.5f + 0.2f, whatIsGround);
        
        Myinput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    


    private void Myinput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;

            jump();

            Invoke(nameof(Resetjump), JumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement diraction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        
        
        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 10f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void Resetjump()
    {
        readyToJump = true;
    }
}
