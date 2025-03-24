using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public float rotationSpeed = 20f;
    public int currentColorIndex = 0;  
    public float rotationDirection = 1f; // 1 for right, -1 for left
    public float cubeScale = 1f; // Scale of the cube
}
