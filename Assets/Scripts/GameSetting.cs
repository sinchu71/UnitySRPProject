using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSetting", menuName = "ScriptableObjects/GameSetting", order = 1)]
public class GameSetting : ScriptableObject
{
    public string playerName = "Player";
    public float volume = 0.5f;
    public int difficulty = 1;
}

