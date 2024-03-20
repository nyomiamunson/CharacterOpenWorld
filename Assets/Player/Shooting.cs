using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Reference to Animator component
    Animator animator;

    public Transform Spawner;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public float bulletDestroyTime = 2f; // Time after which bullet should be destroyed

    // Reference to Rigidbody2D component of the player
    Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to animator component
        animator = GetComponent<Animator>();

        // Get a reference to the Rigidbody2D component of the player
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // If the player is moving, use velocity-based direction
        if (playerRigidbody.velocity.magnitude > 0.1f)
        {
            Vector2 direction = playerRigidbody.velocity.normalized;

            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, Spawner.position, Quaternion.identity);

            // Get Rigidbody2D component of the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Apply force to the bullet in the calculated direction
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);

            // Destroy the bullet after bulletDestroyTime seconds
            Destroy(bullet, bulletDestroyTime);
        }
        // If the player is not moving, use rotation-based direction
        else
        {
            // Get the current state of the Animator
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // Default direction (up) if no specific state is matched
            Vector2 direction = Vector2.up;

            // Determine the direction based on the current state of the Animator
            if (stateInfo.IsName("IdleDown"))
            {
                direction = Vector2.down;
            }
            else if (stateInfo.IsName("IdleRight"))
            {
                direction = Vector2.right;
            }
            else if (stateInfo.IsName("IdleUp"))
            {
                direction = Vector2.up;
            }
            else if (stateInfo.IsName("IdleLeft")) // Handle the "IdleLeft" state
            {
                direction = Vector2.left;
            }
            // Add more conditions for other states as needed

            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, Spawner.position, Quaternion.identity);

            // Get Rigidbody2D component of the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Apply force to the bullet in the calculated direction
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);

            // Destroy the bullet after bulletDestroyTime seconds
            Destroy(bullet, bulletDestroyTime);
        }
    }
}