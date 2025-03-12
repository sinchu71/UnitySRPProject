using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private int bounceCount = 0;

    [SerializeField]
    // Number of times the ball will bounce before stopping
    private int maxBounces = 5; 

    // Time before the ball disappears
    [SerializeField]
    private float destroyTime = 5f; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f) // Check if the collision is mostly with the ground
        {
            bounceCount++;

            if (bounceCount >= maxBounces)
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = false;
            }
        }
    }

    private void OnEnable()
    {
        bounceCount = 0;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;

        Invoke("Deactivate", destroyTime);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
