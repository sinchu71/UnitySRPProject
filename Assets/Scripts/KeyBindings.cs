using UnityEngine;

[CreateAssetMenu(fileName = "KeyBindings", menuName = "ScriptableObjects/KeyBindings")]
public class KeyBindings : ScriptableObject
{
    public KeyCode MoveLeft = KeyCode.A;
    public KeyCode MoveRight = KeyCode.D;
    public KeyCode SpeedUp = KeyCode.W;
    public KeyCode SpeedDown = KeyCode.S;
    public KeyCode ScaleUp = KeyCode.Q;
    public KeyCode ScaleDown = KeyCode.E;
    public KeyCode TextureNext = KeyCode.UpArrow;
    public KeyCode TexturePrevious = KeyCode.DownArrow;
}
