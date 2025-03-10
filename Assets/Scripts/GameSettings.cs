using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public float rotationSpeed = 100f;
        public float jumpHeight = 5f;
        public int maxBalls = 5;
    }


