using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSetting", menuName = "ScriptableObjects/GameSetting", order = 1)]
public class GameSetting : ScriptableObject
{
    public float volume = 0.5f;
    public int difficulty = 1;  // 0 = Easy, 1 = Medium, 2 = Hard
    public string playerName = "Player";
}


