using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "KeyBindings", menuName = "ScriptableObjects/KeyBindings", order = 2)]
    public class KeyBindings : ScriptableObject
    {
        public KeyCode moveLeft = KeyCode.LeftArrow;
        public KeyCode moveRight = KeyCode.RightArrow;
        public KeyCode moveUp = KeyCode.UpArrow;
        public KeyCode moveDown = KeyCode.DownArrow;
    }


