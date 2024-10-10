using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Speed of left/right movement
    public float jumpForce = 7f;        // Force applied when jumping
    public int maxJumps = 2;            // Maximum number of jumps (for double jump)
    
    private Rigidbody2D rb;             // Reference to the Rigidbody2D component
    
    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Call movement methods
        Move();
        Jump();
    }

    void Move()
    {
        // Get horizontal input (left/right arrows or A/D keys)
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Apply horizontal movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {

        // When space is pressed 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply upward force for jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
