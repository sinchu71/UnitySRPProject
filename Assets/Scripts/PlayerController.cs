using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyBindings keyBindings;

        void Start()
        {
            keyBindings = Resources.Load<KeyBindings>("ScriptableObjects/KeyBindings");
            if (keyBindings == null)
        {
            Debug.LogError("KeyBindings ScriptableObject NOT FOUND! Check if 'KeyBindings.asset' exists in Resources/ScriptableObjects.");
            return;
        }
        
            Debug.Log("KeyBindings Loaded Successfully!");
        }

        void Update()
        {
            if (Input.GetKey(keyBindings.moveLeft))
            {
                transform.Translate(Vector3.left * Time.deltaTime);
            }
            if (Input.GetKey(keyBindings.moveRight))
            {
                transform.Translate(Vector3.right * Time.deltaTime);
            }
        }
}


