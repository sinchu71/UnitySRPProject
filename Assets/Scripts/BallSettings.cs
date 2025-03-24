using UnityEngine;

[CreateAssetMenu(fileName = "BallSettings", menuName = "ScriptableObjects/BallSettings", order = 1)]
public class BallSettings : ScriptableObject
{
    public int maxBounces = 3;
    public int minBounces = 1;
    public int maxBounceLimit = 10;

    public int maxActiveBalls = 5;
    public float spawnHeight = 5f;
    public Vector2 spawnAreaSize = new Vector2(10, 10);

    public float bounceHeight = 5f;
    public float ballLifetime = 5f; // Lifetime of the ball in seconds
    public Material ballMaterial;   // Material to be applied to the ball
}
