using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ball1 : MonoBehaviour
{
    // This method is called when the ball becomes active in the scene (enabled).
    private void OnEnable()
    {
        // Check if the CameraPanningSystem instance exists before trying to access it.
        if (CameraPanningSystem.Instance != null)
        {
            // Get the Renderer component attached to this GameObject (the ball).
            Renderer renderer = GetComponent<Renderer>();

            if (renderer != null)
            {
                // Get the color of the ball's material.
                Color ballColor = renderer.material.color;

                // Register this ball's color with the CameraPanningSystem.
                CameraPanningSystem.Instance.RegisterBall(ballColor);
            }
        }
    }

    // This method is called when the ball becomes inactive in the scene (disabled).
    private void OnDisable()
    {
        // Check if the CameraPanningSystem instance exists before trying to access it.
        if (CameraPanningSystem.Instance != null)
        {
            // Get the Renderer component attached to this GameObject (the ball).
            Renderer renderer = GetComponent<Renderer>();

            if (renderer != null)
            {
                // Get the color of the ball's material.
                Color ballColor = renderer.material.color;

                // Unregister this ball's color from the CameraPanningSystem.
                CameraPanningSystem.Instance.UnregisterBall(ballColor);
            }
        }
    }
}
