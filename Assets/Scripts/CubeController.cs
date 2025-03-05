using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the cube's rotation speed, direction, and scaling based on user input.
/// </summary>

public class CubeController : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;      // Default rotation speed
    public float speedIncrement = 10f;     // Speed increase/decrease amount

    [Header("Scaling Settings")]
    public float scaleFactor = 0.1f;       // Scale increment factor
    public float maxScale = 3f;            // Maximum scale size
    public float minScale = 0.5f;          // Minimum scale size

    private float currentSpeed;            // Stores the current rotation speed
    private Vector3 defaultScale;          // Stores the cube's initial scale
    private int rotationDirection = 1;     // 1 for right, -1 for left

    /// <summary>
    /// Initializes default values at the start.
    /// </summary>

    void Start()
    {
        currentSpeed = rotationSpeed;
        defaultScale = transform.localScale;
    }

    /// <summary>
    /// Updates rotation and scaling every frame.
    /// </summary>

    void Update()
    {
        HandleRotation();
        HandleScaling();
    }

    /// <summary>
    /// Handles rotation speed and direction.
    /// </summary>

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.W)) // Increase speed
            currentSpeed += speedIncrement * Time.deltaTime;

        if (Input.GetKey(KeyCode.S)) // Decrease speed
            currentSpeed -= speedIncrement * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) // Rotate left
            rotationDirection = -1;

        if (Input.GetKey(KeyCode.D)) // Rotate right
            rotationDirection = 1;

        // Rotate the cube
        transform.Rotate(Vector3.up * currentSpeed * rotationDirection * Time.deltaTime);
    }

    /// <summary>
    /// Handles scaling up and down.
    /// </summary>
    
    void HandleScaling()
    {
        Vector3 newScale = transform.localScale;

        if (Input.GetKey(KeyCode.Q)) // Scale up
            newScale += Vector3.one * scaleFactor * Time.deltaTime;

        if (Input.GetKey(KeyCode.E)) // Scale down
            newScale -= Vector3.one * scaleFactor * Time.deltaTime;

        // Keep scale within limits
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

        // Apply the new scale
        transform.localScale = newScale;
    }
}




