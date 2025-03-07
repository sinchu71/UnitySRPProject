using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
        [Header("Rotation Settings")]
        public float rotationSpeed = 100f;  // Default rotation speed
        public float speedIncrement = 10f; // Amount by which speed increases or decreases

        [Header("Scaling Settings")]
        public float scaleFactor = 0.1f;   // Amount by which the cube scales
        public float maxScale = 3f;        // Maximum scale limit
        public float minScale = 0.5f;      // Minimum scale limit

        private float currentSpeed;        // Stores the current rotation speed
        private Vector3 defaultScale;      // Stores the cube's original scale
        private int rotationDirection = 1; // 1 for right, -1 for left

        void Start()
        {
            currentSpeed = rotationSpeed;  // Initialize rotation speed
            defaultScale = transform.localScale;  // Store the initial scale
        }

        void Update()
        {
            HandleRotation();  // Manage cube rotation
            HandleScaling();   // Manage cube scaling
        }

        void HandleRotation()
        {
            // Increase rotation speed with W key
            if (Input.GetKey(KeyCode.W))
                currentSpeed += speedIncrement * Time.deltaTime;

            // Decrease rotation speed with S key
            if (Input.GetKey(KeyCode.S))
                currentSpeed -= speedIncrement * Time.deltaTime;

            // Change rotation direction to left with A key
            if (Input.GetKey(KeyCode.A))
                rotationDirection = -1;

            // Change rotation direction to right with D key
            if (Input.GetKey(KeyCode.D))
                rotationDirection = 1;

            // Apply rotation to the cube
            transform.Rotate(Vector3.up * currentSpeed * rotationDirection * Time.deltaTime);
        }

    void HandleScaling()
    {
        Vector3 newScale = transform.localScale;

        // Scale up when 'Q' is pressed
        if (Input.GetKey(KeyCode.Q))
            newScale += Vector3.one * scaleFactor * Time.deltaTime;

        // Scale down when 'E' is pressed
        if (Input.GetKey(KeyCode.E))
            newScale -= Vector3.one * scaleFactor * Time.deltaTime;

        // Prevent negative scale (clamp values)
        newScale.x = Mathf.Max(newScale.x, minScale);
        newScale.y = Mathf.Max(newScale.y, minScale);
        newScale.z = Mathf.Max(newScale.z, minScale);

        // Apply new scale
        transform.localScale = newScale;
    }
}
