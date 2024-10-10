using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Speed of left/right movement
    public float jumpForce = 7f;        // Force applied when jumping
    public int maxJumps = 2;            // Maximum number of jumps (for double jump)
    public float driftSpeed = 0.9f;
    public float decelleration = 0.5f;
    

    private int jumpCount = 0;
    private bool isGrounded = false;
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

        if (moveInput != 0)
        {

            rb.AddForce(new Vector2(moveInput * moveSpeed, 0), ForceMode2D.Force);

            // Apply horizontal movement
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

        else
        {
            // Gradually reduce horizontal velocity (drift effect)
            rb.velocity = new Vector2(rb.velocity.x * driftSpeed, rb.velocity.y);
            
            if (Mathf.Abs(rb.velocity.x) < 0.01f)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    void Jump()
    {

        // When space is pressed 
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            // Apply upward force for jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Landed on platform");

            jumpCount = 0;

            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;

            Debug.Log("Left platform");
        }
    }

}
