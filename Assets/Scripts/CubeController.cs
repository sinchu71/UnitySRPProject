using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [Header("Rotation Settings")]

    // Default rotation speed
    [SerializeField] 
    private float rotationSpeed = 100f;

    // Amount by which speed increases or decreases
    [SerializeField] 
    private float speedIncrement = 10f; 


    [Header("Scaling Settings")]

    // Amount by which the cube scales
    [SerializeField] 
    private float scaleFactor = 0.1f;

    // Maximum scale limit
    [SerializeField] 
    private float maxScale = 3f;

    // Minimum scale limit
    [SerializeField] 
    private float minScale = 0.5f;


    // Stores the current rotation speed
    private float _currentSpeed = 0;

    // Stores the cube's original scale
    private Vector3 _defaultScale = Vector3.one;

    // 1 for right, -1 for left
    private int _rotationDirection = 1; 

    void Start()
    {
        // Initialize rotation speed
        _currentSpeed = rotationSpeed;  

        // Store the initial scale
        _defaultScale = transform.localScale;  
    }

    void Update()
    {
        // Manage cube rotation
        handleRotation();  

        // Manage cube scaling
        handleScaling();   
    }

    void handleRotation()
    {
        // Increase rotation speed with W key
        if (Input.GetKey(KeyCode.W))
            _currentSpeed += speedIncrement * Time.deltaTime;

        // Decrease rotation speed with S key
        if (Input.GetKey(KeyCode.S))
            _currentSpeed -= speedIncrement * Time.deltaTime;

        // Cap rotation speed to avoid negative values
        _currentSpeed = Mathf.Max(0, _currentSpeed);

        // Change rotation direction to left with A key
        if (Input.GetKey(KeyCode.A))
            _rotationDirection = -1;

        // Change rotation direction to right with D key
        if (Input.GetKey(KeyCode.D))
            _rotationDirection = 1;

        // Apply rotation to the cube
        transform.Rotate(Vector3.up * _currentSpeed * _rotationDirection * Time.deltaTime);
    }

    void handleScaling()
    {
        Vector3 newScale = transform.localScale;

        // Scale up when 'Q' is pressed
        if (Input.GetKey(KeyCode.Q))
            newScale += Vector3.one * scaleFactor * Time.deltaTime;

        // Scale down when 'E' is pressed
        if (Input.GetKey(KeyCode.E))
            newScale -= Vector3.one * scaleFactor * Time.deltaTime;

        // Clamp scale values to stay within the min and max scale limits
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

        // Apply new scale
        transform.localScale = newScale;
    }
}
