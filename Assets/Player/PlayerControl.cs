using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Refernce to Animator component
    Animator animator;
    // Reference to SpriteRenderer component
    SpriteRenderer spriteRenderer;
    // Reference to RigidBody2D component for physics-based movement
    Rigidbody2D rb;

    bool wasMovingLeft = false; // Track if moving left

    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to components
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        bool isMovingRight = Input.GetKey(KeyCode.RightArrow);
        bool isMovingLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isMovingUp = Input.GetKey(KeyCode.UpArrow);
        bool isMovingDown = Input.GetKey(KeyCode.DownArrow);

        // Handle movement animations and physics-based movement
        Vector2 movement = Vector2.zero;
        if (isMovingRight)
        {
            movement = Vector2.right;
            animator.SetBool("Right", true);
            spriteRenderer.flipX = false;
            wasMovingLeft = false;
        }
        else if (isMovingLeft)
        {
            movement = Vector2.left;
            animator.SetBool("Right", true);
            spriteRenderer.flipX = true;
            wasMovingLeft = true;
        }
        else if (isMovingUp)
        {
            movement = Vector2.up;
            animator.SetBool("Right", false);
        }
        else if (isMovingDown)
        {
            movement = Vector2.down;
            animator.SetBool("Right", false);
        }
        else
        {
            // No movement, reset animation states
            animator.SetBool("Right", false);
            if (wasMovingLeft)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }

        // Apply movement velocity to RigidBody2D
        rb.velocity = movement * speed;

        // Set animator parameters for vertical movement
        animator.SetBool("Up", isMovingUp);
        animator.SetBool("Down", isMovingDown);
    }
}