using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameSettings gameSettings;
    public KeyBindings keyBindings;

    void Start()
    {
    gameSettings = Resources.Load<GameSettings>("ScriptableObjects/GameSettings");
    keyBindings = Resources.Load<KeyBindings>("ScriptableObjects/KeyBindings");

    if (gameSettings == null || keyBindings == null)
    {
    Debug.LogError("ScriptableObjects not found in Resources folder!");
    return;
    }

    Debug.Log("GameSettings and KeyBindings Loaded!");
    Debug.Log("Rotation Speed: " + gameSettings.rotationSpeed);
    Debug.Log("Move Left Key: " + keyBindings.moveLeft);
    }
}

