using UnityEngine;
using System.Collections.Generic;

public class ballSpawner1 : MonoBehaviour
{   
    [SerializeField] private GameObject ballPrefab;     // The ball prefab to spawn
    [SerializeField] private Transform spawnPoint;      // The point where balls will be spawned
    [SerializeField] private int ballCount = 0;         // Tracks the total number of balls spawned

    /// <summary>
    /// Spawns a specified number of balls at the spawn point.
    /// </summary>
    /// <param name="numberOfBalls">The number of balls to spawn.</param>
    public void SpawnBalls(int numberOfBalls)
    {
        // Check if the required objects are assigned
        if (ballPrefab == null || spawnPoint == null) return;

        for (int i = 0; i < numberOfBalls; i++)
        {
            // Instantiate a new ball at the spawn point with no rotation
            GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            
            // Attempt to get the Renderer component of the new ball
            Renderer renderer = newBall.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Retrieve the ball's current color and register it
                Color ballColor = renderer.material.color;
                CameraPanningSystem.Instance.RegisterBall(ballColor);

                // Increase the ball count
                ballCount++;
                
                // Log the spawn event with color and count details
                Debug.Log($"Ball Spawned. Color: {ballColor}. Total Balls: {ballCount}");
            }
        }
    }

    /// <summary>
    /// Despawns a specified number of balls from the scene.
    /// </summary>
    /// <param name="numberOfBalls">The number of balls to despawn.</param>
    public void DespawnBalls(int numberOfBalls)
    {
        // Find all existing balls with the "Ball" tag
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        int despawnedCount = 0;

        foreach (GameObject ball in balls)
        {
            // Stop if the desired number of balls are despawned
            if (despawnedCount >= numberOfBalls) break;

            // Attempt to get the Renderer component of the ball
            Renderer renderer = ball.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Retrieve the ball's current color and unregister it
                Color ballColor = renderer.material.color;
                CameraPanningSystem.Instance.UnregisterBall(ballColor);

                // Decrease the ball count
                ballCount--;
                despawnedCount++;
                
                // Log the despawn event with color and count details
                Debug.Log($"Ball Despawned. Color: {ballColor}. Remaining Balls: {ballCount}");
            }

            // Destroy the ball object
            Destroy(ball);
        }
    }
}
