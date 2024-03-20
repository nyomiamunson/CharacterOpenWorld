using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Refernce to Animator component
    Animator animator;

    public Transform Spawner;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to animator component
        animator = GetComponent<Animator>();
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
        GameObject bullet = Instantiate(bulletPrefab, Spawner.position, Spawner.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    }
}
