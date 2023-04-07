using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f; // The speed at which the player moves
    public float jumpForce = 10f; // The force with which the player jumps
    public LayerMask groundLayers; // A layer mask that defines what counts as ground for the player

    private Rigidbody rb; // The player's rigidbody component
    private Animator animator; // The player's animator component
    private bool isFacingRight = true; // Whether the player is facing right or left
    private bool isGrounded = false; // Whether the player is currently grounded or not

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector2.down, 0.1f, groundLayers);

        // Get the player's horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        // Move the player horizontally
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;

        Vector2 movementvertical = new Vector2(verticalInput * speed, rb.velocity.x);
        rb.velocity = movement;

        // Flip the player's sprite if necessary
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }

        // Play the running animation if the player is moving horizontally
        animator.SetBool("isRunning", Mathf.Abs(horizontalInput) > 0);

        // Check if the player should jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("jump");
        }
    }

    void Flip()
    {
        // Flip the player's sprite
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
