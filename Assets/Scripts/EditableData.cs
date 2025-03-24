using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EditableData", order = 1)]
public class EditableData : ScriptableObject
{
    public string savedText = "";
    public Color uiColor = Color.white;
}
